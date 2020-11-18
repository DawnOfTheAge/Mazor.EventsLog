using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using General.Database.Common;

namespace General.Database.SqlServer
{
    public class SqlServerDal : IRepositoryDatabase
    {
        #region Events

        public event EventHandler RepositoryDatabaseMessage;

        #endregion

        #region Enums

        private enum ColumnType
        {
            Unknown,
            Integer,
            String,
            DateTime
        }

        #endregion

        #region Data Types

        private class Field
        {
            public Field(string name, string type)
            {
                Name = name;
                Type = type;
            }

            public string Name { get; set; }

            public string Type { get; set; }
        }

        private class Table
        {
            public Table(string name)
            {
                Name = name;
                Fields = new List<Field>();
            }

            public string Name { get; set; }

            public List<Field> Fields { get; set; }

            public bool AddField(string name, string type, out string result)
            {
                result = string.Empty;

                try
                {
                    if (Fields == null)
                    {
                        result = "'Fields' Is Null";

                        return false;
                    }

                    Fields.Add(new Field(name, type));

                    return true;
                }
                catch (Exception e)
                {
                    result = e.Message;

                    return false;
                }
            }

            public bool GenerateSqlCreateCommand(out string createCommand, out string result)
            {
                result = string.Empty;
                createCommand = string.Empty;

                try
                {
                    if ((Fields == null) || (Fields.Count == 0))
                    {
                        result = "No Fields";

                        return false;
                    }

                    createCommand = "CREATE TABLE " + Name + " (";

                    foreach (Field currentField in Fields)
                    {
                        createCommand += currentField.Name + " " + currentField.Type + ",";
                    }

                    createCommand = createCommand.Substring(0, createCommand.Length - 1);
                    createCommand += ")";

                    return true;
                }
                catch (Exception e)
                {
                    result = e.Message;

                    return false;
                }
            }
        }

        #endregion

        #region Constants

        private const string CSV_FILE_EXTENSION = ".CSV";

        private const int NUMBER_OF_FIELD_PROPERTIES = 2;

        #endregion

        #region Data Members

        private SqlConnection _connection;

        private string _dbName;

        private string[] _table;

        #endregion

        #region Properties

        /// <summary>
        /// Port of the PostgreSQL DB default is 27017
        /// </summary>
        public string IpPort { get; set; }

        /// <summary>
        /// IP of the PostgreSQL DB. Default is localhost
        /// </summary>
        public string IpAddress { get; set; }

        #endregion

        #region Database

        //  Purpose:        PostgreSQL database DAL CTOR
        //  Input:          none
        //  Output:         none
        public SqlServerDal()
        {
            IpAddress = "localhost";
            IpPort = "5432";
        }

        //  Purpose:        Open database
        //  Input:          databaseParameters - see ContextRepositoryDataTypes.OpenDatabaseParameters in ContextRepository.Commom\Data Types.cs
        //                  result - [out] string
        //  Output:         true / false
        public bool OpenDb(OpenDatabaseParameters databaseParameters, out string result)
        {
            string report = string.Empty;
            string ipPort;
            result = string.Empty;

            try
            {
                ipPort = (string.IsNullOrEmpty(databaseParameters.DatabaseIpPort)) ? "" : ("," + databaseParameters.DatabaseIpPort);

                string connectionString = "Data Source=" + databaseParameters.DatabaseIpAddress + 
                                          ipPort +
                                          ";Persist Security Info=True;User Id=" + databaseParameters.DatabaseUsername +
                                          ";Password=" + databaseParameters.DatabasePassword + ";Min Pool Size=1";
                _connection = new SqlConnection(connectionString);

                report = "Connection String[" + connectionString + "]";

                _connection.Open();

                if (!DatabaseExists(databaseParameters.DatabaseName, out result))
                {
                    if (!NonQuery("CREATE DATABASE " + databaseParameters.DatabaseName, out result))
                    {
                        result = report + Environment.NewLine + result;

                        return false;
                    }

                    report += Environment.NewLine + "Database '" + databaseParameters.DatabaseName + "' Created";
                }

                _dbName = databaseParameters.DatabaseName;

                _connection.Close();
                connectionString += ";Initial Catalog=" + databaseParameters.DatabaseName.ToLower() + ";";

                report += Environment.NewLine + "Connection String Changed With Database Name[" + connectionString + "]";

                _connection = new SqlConnection(connectionString);
                _connection.Open();

                _table = Utils.GetAllSubStrings(databaseParameters.DatabaseTables, ":");                

                if (_table != null)
                {
                    //  get all needed tables/collections
                    foreach (string currentTable in _table)
                    {
                        //  if table/collection exists do nothing
                        if (TableExists(currentTable, out result))
                        {
                            report += Environment.NewLine + "Table[" + currentTable + "] exists";

                            continue;
                        }
                        
                        if (!string.IsNullOrEmpty(result))
                        {
                            report += Environment.NewLine + result;
                        }

                        if (string.IsNullOrEmpty(databaseParameters.DatabaseTableFieldsCsvPath))
                        {
                            report += Environment.NewLine + "Path to Database Table Fields Csv File Does Not Exist";

                            break;
                        }

                        Table table; 
                        if (!ExtractTableFieldsTypes(databaseParameters.DatabaseTableFieldsCsvPath, currentTable, out table, out result))
                        {
                            result = report + Environment.NewLine + result;

                            continue;
                        }

                        string currentCreateCommand;
                        if (!table.GenerateSqlCreateCommand(out currentCreateCommand, out result))
                        {
                            report += Environment.NewLine + result;

                            continue;
                        }

                        //  if table/collection does not exist create it
                        if (!CreateTable(currentTable, currentCreateCommand, out result))
                        {

                        }

                        report += Environment.NewLine + result;
                    }
                }
                else
                {
                    report += Environment.NewLine + "No tables in list";
                    result = report;

                    return false;
                }

                result = report;

                return true;
            }
            catch (Exception e)
            {
                result = report + Environment.NewLine + e.Message;

                return false;
            }
        }

        //  Purpose:        Is PostgreSQL database connected
        //  Input:          result - out result
        //  Output:         true / false
        public bool IsConnected(out string result)
        {
            result = string.Empty;

            try
            {
                if (_connection != null)
                {
                    bool connectionResult;
                    if (_connection.State == ConnectionState.Open)
                    {
                        result = "Connected";

                        connectionResult = true;
                    }
                    else
                    {
                        result = "Could Not Connect";

                        connectionResult = false;
                    }

                    return connectionResult;
                }
                
                result = "Connection Is Null";

                return false;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        //  Purpose:        Close PostgreSQL database 
        //  Input:          result - [out] result
        //  Output:         true / false
        public bool CloseDb(out string result)
        {
            result = string.Empty;

            try
            {
                if (_connection != null)
                {
                    _connection.Close();

                    return true;
                }

                result = "Connection Is Null";

                return false;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        #endregion

        #region Actions

        //  Purpose:        Insert records, one or more into table 'tableName'
        //  Input:          tableName 
        //                  recordFields
        //                  [out] newId
        //                  result - [out] result
        //  Output:         true / false
        public bool Insert(string tableName, Dictionary<string, string> recordFields, out string newId, out string result)
        {
            result = string.Empty;
            newId = string.Empty;

            try
            {
                string fields;
                string values;

                Dictionary<string, Type> recordFieldTypes = new Dictionary<string, Type>();

                foreach (KeyValuePair<string, string> recordField in recordFields)
                {
                    recordFieldTypes.Add(recordField.Key, typeof(string));
                }

                if (!ExtractFieldsAndValues(recordFields, recordFieldTypes, out fields, out values, out result))
                {
                    return false;
                }

                if (!NonQuery("INSERT INTO " + tableName + "(" + fields + ") VALUES (" + values + ")", out result))
                {
                    return false;
                }

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        //  Purpose:        Insert records, one or more into table 'tableName'
        //  Input:          tableName 
        //                  recordFields
        //                  recordFieldTypes
        //                  [out] newId
        //                  result - [out] result
        //  Output:         true / false
        public bool Insert(string tableName, 
                           Dictionary<string, string> recordFields, 
                           Dictionary<string, Type> recordFieldTypes, 
                           out string newId, 
                           out string result)
        {
            result = string.Empty;
            newId = string.Empty;

            try
            {
                string fields;
                string values;


                if (!ExtractFieldsAndValues(recordFields, recordFieldTypes, out fields, out values, out result))
                {
                    return false;
                }

                if (!NonQuery("INSERT INTO " + tableName + "(" + fields + ") VALUES (" + values + ")", out result))
                {
                    return false;
                }

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        //  Purpose:        Update record with new value to 'targetField' field by key field 'keyField' in table 'tableName'
        //  Input:          tableName 
        //                  keyField
        //                  keyFieldType
        //                  keyFieldValue
        //                  targetField
        //                  targetFieldType
        //                  targetFieldNewValue
        //                  result - [out] result
        //  Output:         true / false
        public bool Update(string tableName, 
                           string keyField,
                           Type keyFieldType,
                           string keyFieldValue,
                           string targetField,
                           Type targetFieldType,
                           string targetFieldNewValue, 
                           out string result)
        {
            result = string.Empty;

            try
            {
                if (keyFieldType == typeof (string))
                {
                    if (!CommentFieldValue(ref keyFieldValue, out result))
                    {
                        return false;
                    }
                }

                if (targetFieldType == typeof(string))
                {
                    if (!CommentFieldValue(ref targetFieldNewValue, out result))
                    {
                        return false;
                    }
                }

                if (!NonQuery("UPDATE " + tableName + 
                              " SET " + targetField + " = " + targetFieldNewValue +
                              " WHERE " + keyField + " = " + keyFieldValue, out result))
                {
                    return false;
                }

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        //  Purpose:        Retrieve records, one or more from table 'tableName'
        //  Input:          tableName 
        //                  filter - search criteria
        //                  records - the fetched documents
        //                  result - [out] result
        //  Output:         true / false
        public bool Retrieve(string tableName, Dictionary<string, string> filter, out List<List<string>> records, out string result)
        {
            string method = "[" + MethodBase.GetCurrentMethod().Name + "]: ";
            string sqlConditions = string.Empty;

            result = string.Empty;
            records = null;

            try
            {
                if ((filter != null) && (filter.Count > 0))
                {
                    if (!CommentFieldsValues(tableName, ref filter, out result))
                    {
                        return false;
                    }

                    if (!CreateSqlConditions(filter, out sqlConditions, out result))
                    {
                        return false;
                    }
                }

                if (!Query("SELECT * FROM " + tableName + sqlConditions, out records, out result))
                {
                    return false;
                }

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        //  Purpose:        Document with 'field' == 'value' exists in the table 'tableName'
        //  Input:          tableName 
        //                  fieldName - criteria
        //                  fieldType
        //                  fieldValue - the value of 'fieldName'
        //                  result - [out] result
        //  Output:         true / false
        public bool RecordExists(string tableName, string fieldName, Type fieldType, string fieldValue, out string result)
        {
            result = string.Empty;

            try
            {
                List<List<string>> records;

                if (fieldType == typeof (string))
                {
                    if (!CommentFieldValue(ref fieldValue, out result))
                    {
                        return false;
                    }
                }

                if (!Query("SELECT COUNT(*) FROM " + tableName + " WHERE " + fieldName + " = " + fieldValue, out records, out result))
                {
                    return false;
                }

                if (records != null)
                {

                    int count = (int.TryParse(records[0][0], out count)) ? count : Constants.NONE;

                    return (count >= 1);
                }

                result = "Sql Qurey Result Is Null";

                return false;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        //  Purpose:        Remove record with 'field' == 'value' from table 'tableName'
        //  Input:          tableName 
        //                  fieldName - criteria
        //                  fieldType
        //                  fieldValue - the value of 'fieldName'
        //                  result - [out] result
        //  Output:         true / false
        public bool Remove(string tableName, string fieldName, Type fieldType, string fieldValue, out string result)
        {
            result = string.Empty;

            try
            {
                if (fieldValue == "{}")
                {
                    return DeleteAllTableRecords(tableName, out result);
                }
                else
                {
                    return RemoveRecord(tableName, fieldName, fieldType, fieldValue, out result);
                }
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        //  Purpose:        Sum all 'accumulationField' where 'fieldName' == 'fieldValue' from table 'tableName'
        //  Input:          tableName 
        //                  fieldName - criteria
        //                  fieldType
        //                  fieldValue - the value of 'fieldName'
        //                  accumulationField
        //                  result - [out] result
        //  Output:         sum result
        public int Sum(string tableName, string fieldName, Type fieldType, string fieldValue, string accumulationField, out string result)
        {
            string method = "[" + MethodBase.GetCurrentMethod().Name + "]: ";

            int sum;
            result = string.Empty;

            try
            {
                if (fieldType == typeof(string))
                {
                    if (!CommentFieldValue(ref fieldValue, out result))
                    {
                        return Constants.NONE;
                    }
                }

                List<List<string>> records;
                if (!Query("SELECT SUM(" + accumulationField + ") FROM " + tableName + " WHERE " + fieldName + " = " + fieldValue,
                           out records, 
                           out result))
                {
                    return Constants.NONE;
                }

                if (records == null)
                {
                    result = "Sql Qurey Result Is Null";

                    return Constants.NONE;
                }

                sum = (int.TryParse(records[0][0], out sum)) ? sum : Constants.NONE;

                return sum;
            }
            catch (Exception e)
            {
                result = "Failed sum '" + accumulationField + "' for '" + fieldName + "' = " + fieldValue + " from table [" + tableName + "]." + e.Message;

                OnContextRepositoryDatabaseMessage(method + result + ". Line " + Utils.GetLineNumber(e));

                return Constants.NONE;
            }
        }

        //  Purpose:        Count number of documents where 'fieldName' == 'fieldValue' in table 'tableName'
        //  Input:          tableName 
        //                  fieldName - criteria
        //                  fieldType
        //                  fieldValue - the value of 'fieldName'
        //                  result - [out] result
        //  Output:         sum result
        public int Count(string tableName, string fieldName, Type fieldType, string fieldValue, out string result)
        {
            string method = "[" + MethodBase.GetCurrentMethod().Name + "]: ";

            int count;

            result = string.Empty;

            try
            {
                if (fieldType == typeof(string))
                {
                    if (!CommentFieldValue(ref fieldValue, out result))
                    {
                        return Constants.NONE;
                    }
                }

                List<List<string>> records;
                if (!Query("SELECT COUNT(*) FROM " + tableName + " WHERE " + fieldName + " = " + fieldValue,
                           out records,
                           out result))
                {
                    return Constants.NONE;
                }

                if (records == null)
                {
                    result = "Sql Qurey Result Is Null";

                    return Constants.NONE;
                }

                count = (int.TryParse(records[0][0], out count)) ? count : Constants.NONE;

                return count;
            }
            catch (Exception e)
            {
                result = "Failed count number of appearances of '" + fieldName + "' = " + fieldValue + " from table [" + tableName + "]." + e.Message;

                OnContextRepositoryDatabaseMessage(method + result + ". Line " + Utils.GetLineNumber(e));

                return Constants.NONE;
            }
        }

        //  Purpose:        Distinct values of 'idField' from table 'tableName'
        //  Input:          tableName 
        //                  idField 
        //                  [out] list of distinct 'idField' values    
        //                  result - [out] result
        //  Output:         true / false
        //  Assumptions:    none
        public bool Distinct(string tableName, string idField, out List<string> distictList, out string result)
        {
            string method = "[" + MethodBase.GetCurrentMethod().Name + "]: ";

            distictList = new List<string>();

            result = string.Empty;

            try
            {
                List<List<string>> records;
                if (!Query("SELECT DISTINCT(" + idField + ") FROM " + tableName, out records, out result))
                {
                    return false;
                }

                if (records == null)
                {
                    result = "Sql Qurey Result Is Null";

                    return false;
                }

                foreach (List<string> record in records)
                {
                    distictList.Add(record[0]);
                }

                return true;
            }
            catch (Exception e)
            {
                result = "Failed DISTINCT for '" + idField + "' from table [" + tableName + "]." + e.Message;

                OnContextRepositoryDatabaseMessage(method + result + ". Line " + Utils.GetLineNumber(e));

                return false;
            }
        }

        //  Purpose:        Get wanted fields values by field,value pairs as criteria from table 'tableName'
        //  Input:          tableName 
        //                  fieldValue - criteria field,value pairs
        //                  wantedField - the fields to be retrieved
        //                  result - [out] result
        //  Output:         list of wanted fields values
        public List<string> GetBy(string tableName, Dictionary<string, string> fieldValue, List<string> wantedField, out string result)
        {
            string method = "[" + MethodBase.GetCurrentMethod().Name + "]: ";
            string sqlWantedFields;
            string sqlConditions = string.Empty;

            List<string> lValue;

            result = string.Empty;

            try
            {
                if ((wantedField == null) || (wantedField.Count == 0))
                {
                    result = "Wanted Fields List Is Null Or Empty";

                    return null;
                }

                sqlWantedFields = string.Empty;
                foreach (string currentField in wantedField)
                {
                    sqlWantedFields += currentField + ",";
                }

                sqlWantedFields = sqlWantedFields.Substring(0, sqlWantedFields.Length - 1);

                if ((fieldValue != null) && (fieldValue.Count > 0))
                {
                    if (!CommentFieldsValues(tableName, ref fieldValue, out result))
                    {
                        return null;
                    }

                    if (!CreateSqlConditions(fieldValue, out sqlConditions, out result))
                    {
                        return null;
                    }
                }

                List<List<string>> records;
                if (!Query("SELECT " + sqlWantedFields + " FROM " + tableName + sqlConditions, out records, out result))
                {
                    return null;
                }

                if (records == null)
                {
                    result = "Sql Qurey Result Is Null";

                    return null;
                }

                lValue = new List<string>();

                for (int i = 0; i < records[0].Count; i++)
                {
                    lValue.Add(records[0][i]);
                }

                return lValue;
            }
            catch (Exception e)
            {
                result = "Failed getting wanted fields {} by these fields and values from collection [" + tableName + "]." + e.Message;

                OnContextRepositoryDatabaseMessage(method + result + ". Line " + Utils.GetLineNumber(e));

                return null;
            }
        }

        //  Purpose:        Get record from table 'tableName' where 'fieldName' is maximal 
        //  Input:          tableName 
        //                  recordFields
        //                  fieldName 
        //                  record - [out] the retrieved record
        //                  result - [out] result
        //  Output:         true / false
        public bool Max(string tableName, List<string> recordFields, string fieldName, out List<string> record, out string result)
        {
            string method = "[" + MethodBase.GetCurrentMethod().Name + "]: ";

            result = string.Empty;
            record = null;

            try
            {
                string fields;

                if (string.IsNullOrEmpty(fieldName))
                {
                    result = "Sort Field Name List Is Empty Or Null";

                    return false;
                }

                if ((recordFields == null) || (recordFields.Count == 0))
                {
                    result = "Wanted Records Fields List Is Empty Or Null";

                    return false;
                }

                if ((recordFields.Count == 1) && (recordFields[0] == "*"))
                {
                    fields = "*";
                }
                else
                {
                    if (!ExtractFields(recordFields, out fields, out result))
                    {
                        return false;
                    }
                }

                List<List<string>> records;
                if (!Query("SELECT" + fields + " FROM " + tableName + " ORDER BY " + fieldName + " DESC", out records, out result))
                {
                    return false;
                }

                if (!ConvertRecordToList(records, out record, out result))
                {
                    return false;
                }

                return true;
            }
            catch (Exception e)
            {
                result = "Failed Finding Record For Maximum Of Field '" + fieldName + "' From Table [" + tableName + "]." + e.Message;

                OnContextRepositoryDatabaseMessage(method + e.Message + ". Line " + Utils.GetLineNumber(e));

                return false;
            }
        }

        //  Purpose:        Get record from table 'tableName' where 'fieldName' is minimal 
        //  Input:          tableName 
        //                  recordFields
        //                  fieldName 
        //                  record - [out] the retrieved record
        //                  result - [out] result
        //  Output:         true / false
        public bool Min(string tableName, List<string> recordFields, string fieldName, out List<string> record, out string result)
        {
            string method = "[" + MethodBase.GetCurrentMethod().Name + "]: ";

            result = string.Empty;
            record = null;

            try
            {
                string fields;

                if (string.IsNullOrEmpty(fieldName))
                {
                    result = "Sort Field Name List Is Empty Or Null";

                    return false;
                }

                if ((recordFields == null) || (recordFields.Count == 0))
                {
                    result = "Wanted Records Fields List Is Empty Or Null";

                    return false;
                }

                if ((recordFields.Count == 1) && (recordFields[0] == "*"))
                {
                    fields = "*";
                }
                else
                {
                    if (!ExtractFields(recordFields, out fields, out result))
                    {
                        return false;
                    }
                }

                List<List<string>> records;
                if (!Query("SELECT" + fields + " FROM " + tableName + " ORDER BY " + fieldName + " ASC", out records, out result))
                {
                    return false;
                }

                if (!ConvertRecordToList(records, out record, out result))
                {
                    return false;
                }

                return true;
            }
            catch (Exception e)
            {
                result = "Failed Finding Record For Maximum Of Field '" + fieldName + "' From Table [" + tableName + "]." + e.Message;

                OnContextRepositoryDatabaseMessage(method + e.Message + ". Line " + Utils.GetLineNumber(e));

                return false;
            }
        }

        #endregion

        #region Tables

        //  Purpose:        Table 'tableName' exists?
        //  Input:          tableName 
        //                  result - [out] result
        //  Output:         true / false
        //  Assumptions:    none
        private bool TableExists(string tableName, out string result)
        {
            result = string.Empty;

            try
            {
                List<List<string>> records;
                if (!Query("SELECT table_name FROM information_schema.tables", out records, out result))
                {
                    return false;
                }

                if (records != null)
                {
                    bool returnCode = false;
                    foreach (List<string> record in records)
                    {
                        string currentTable = record[0];

                        if (currentTable.ToLower() == tableName.ToLower())
                        {
                            returnCode = true;
                        }
                    }

                    if (!returnCode)
                    {
                        result = "Table '" + tableName + "' Not Found";
                    }

                    return returnCode;
                }

                result = "Null Records";

                return false;
            }
            catch (Exception e)
            {
                result = "Could not determine if Table[" + tableName + "] exists. " + e.Message;

                return false;
            }
        }

        //  Purpose:        Create table 'tableName'
        //  Input:          tableName 
        //                  createTableCommand
        //                  result - [out] result
        //  Output:         true / false
        private bool CreateTable(string tableName, string createTableCommand, out string result)
        {
            result = string.Empty;

            try
            {
                if (TableExists(tableName, out result))
                {
                    result = "Table with name:[" + tableName + "] already exists. ";

                    return true;
                }
                else
                {
                    if (!NonQuery(createTableCommand, out result))
                    {
                        return false;
                    }

                    _connection.Close();
                    _connection.Open();

                    result = "Creating a new table with the name:[" + tableName + "]";

                    return true;
                }
            }
            catch (Exception e)
            {
                result = "Creating a new table with the name:[" + tableName + "] failed. " + e.Message;

                return false;
            }
        }

        #endregion

        #region Records

        //  Purpose:        Delete all records of table 'tableName'
        //  Input:          tableName 
        //                  result - [out] result
        //  Output:         true / false
        private bool DeleteAllTableRecords(string tableName, out string result)
        {
            result = string.Empty;
            string method = "[" + MethodBase.GetCurrentMethod().Name + "]: ";

            try
            {
                if (!NonQuery("DELETE FROM " + tableName, out result))
                {
                    return false;
                }

                return true;
            }
            catch (Exception e)
            {
                result = "Deleteing all records from table:[" + tableName + "] failed. " + e.Message;

                OnContextRepositoryDatabaseMessage(method + result + ". Line " + Utils.GetLineNumber(e));

                return false;
            }
        }

        //  Purpose:        Remove record by 'field' == 'value' of table 'tableName'
        //  Input:          tableName 
        //                  fieldName
        //                  fieldType
        //                  fieldValue
        //                  result - [out] result
        //  Output:         true / false
        private bool RemoveRecord(string tableName, string fieldName, Type fieldType, string fieldValue, out string result)
        {
            string method = "[" + MethodBase.GetCurrentMethod().Name + "]: ";

            result = string.Empty;

            try
            {
                if (fieldType == typeof(string))
                {
                    if (!CommentFieldValue(ref fieldValue, out result))
                    {
                        return false;
                    }
                }

                if (!NonQuery("DELETE FROM " + tableName + " WHERE " + fieldName + " = " + fieldValue, out result))
                {
                    return false;
                }

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                OnContextRepositoryDatabaseMessage(method + "An Excepion occurd while deleting a record in table '. " + e.Message + ". Line " + Utils.GetLineNumber(e));

                return false;
            }
        }

        #endregion

        #region Sql

        //  Purpose:        execute a SQL command and return the results
        //  Input:          sqlCommand 
        //                  [out] records
        //                  [out] result
        //  Output:         true / false
        public bool Query(string sqlCommand, out List<List<string>> records, out string result)
        {
            result = string.Empty;

            records = null;

            try
            {
                SqlCommand command = new SqlCommand(sqlCommand, _connection);
                SqlDataReader dataReader = command.ExecuteReader();

                if (dataReader == null)
                {
                    result = "Sql Qurey Result Is Null";

                    return false;
                }

                records = new List<List<string>>();
                while (dataReader.Read())
                {
                    List<string> record = new List<string>();

                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        record.Add(dataReader[i].ToString());
                    }

                    records.Add(record);
                }

                dataReader.Close();

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;
    
                return false;
            }
        }

        //  Purpose:        execute a SQL command
        //  Input:          sqlCommand 
        //                  [out] result
        //  Output:         true / false
        public bool NonQuery(string sqlCommand, out string result)
        {
            result = string.Empty;

            try
            {
                SqlCommand command = new SqlCommand(sqlCommand, _connection);
                SqlDataReader dataReader = command.ExecuteReader();

                if (dataReader != null)
                {
                    dataReader.Close();
                }

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        //  Purpose:        convert record to list
        //  Input:          records 
        //                  [out] record
        //                  [out] result
        //  Output:         true / false
        private bool ConvertRecordToList(List<List<string>> records, out List<string> record, out string result)
        {
            result = string.Empty;
            record = new List<string>();

            try
            {
                if (records != null)
                {
                    foreach (List<string> currentRecord in records)
                    {
                        for (int i = 0; i < currentRecord.Count; i++)
                        {
                            record.Add(currentRecord[i].ToString());
                        }
                    }

                    return true;
                }

                return false;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        //  Purpose:        database exists?
        //  Input:          databaseName 
        //                  [out] result
        //  Output:         true / false
        private bool DatabaseExists(string databaseName, out string result)
        {
            bool returnCode;

            result = string.Empty;

            try
            {
                returnCode = false;

                List<List<string>> records;
                if (!Query("SELECT name FROM master.dbo.sysdatabases WHERE name = '" + databaseName + "'", out records, out result))
                {
                    return false;
                }

                if (records != null)
                {
                    for (int i = 0; i < records.Count; i++)
                    {
                        string currentDatabaseName = records[i][0];

                        if (currentDatabaseName.ToLower() == databaseName.ToLower())
                        {
                            returnCode = true;

                            break;
                        }
                    }
                }

                if (!returnCode)
                {
                    result = "Database Name[" + databaseName + "] Not Found In 'pg_catalog.pg_database'";
                }

                return returnCode;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        //  Purpose:        get column data type (for now integer/ datetime/string)
        //  Input:          tableName 
        //                  columnName
        //                  [out] columnType
        //                  [out] result
        //  Output:         true / false
        private bool GetColumnType(string tableName, string columnName, out ColumnType columnType, out string result)
        {
            result = string.Empty;
            columnType = ColumnType.Unknown;

            try
            {
                List<List<string>> records;
                if (!Query("SELECT data_type FROM information_schema.columns WHERE table_name = '" + tableName.ToLower() + 
                           "' AND column_name = '" + columnName.ToLower() + "'", 
                           out records, 
                           out result))
                {
                    return false;
                }

                if (records == null)
                {
                    result = "Sql Qurey Result Is Null";

                    return false;
                }

                string type = records[0][0].ToString();

                if (string.IsNullOrEmpty(type))
                {
                    result = "No Data Type Found For Column[" + columnName + "] In Table[" + tableName + "]";

                    return false;
                }

                switch (type)
                {
                    case "integer":
                        columnType = ColumnType.Integer;
                        break;

                    case "character varying":
                        columnType = ColumnType.String;
                        break;

                    case "timestamp without time zone":
                        columnType = ColumnType.DateTime;
                        break;

                        default:
                        columnType = ColumnType.Unknown;
                        break;
                }

                return true;
            }
            catch (Exception e)
            {
                columnType = ColumnType.Unknown;
                result = e.Message;
                
                return false;
            }
        }

        #endregion

        #region Utils

        //  Purpose:        extract fields and their values from a dictionary and return them separated with comma delimiter between them
        //  Input:          recordFields 
        //                  recordFieldTypes
        //                  [out] fields    
        //                  [out] values    
        //                  [out] result
        //  Output:         true / false
        private bool ExtractFieldsAndValues(Dictionary<string, string> recordFields, 
                                            Dictionary<string, Type> recordFieldTypes, 
                                            out string fields, 
                                            out string values, 
                                            out string result)
        {
            result = string.Empty;
            fields = string.Empty;
            values = string.Empty;

            try
            {
                if ((recordFields == null) || (recordFields.Count == 0))
                {
                    result = "Record Fields Dictionary Is Null Or Empty";

                    return false;
                }

                foreach (KeyValuePair<string, string> currentFieldValue in recordFields)
                {
                    string currentField = currentFieldValue.Key;
                    string currentValue = currentFieldValue.Value;

                    Type type = recordFieldTypes[currentField];

                    if ((type == typeof (string)) || (type == typeof (DateTime)))
                    {
                        CommentFieldValue(ref currentValue, out result);
                    }

                    fields += currentField + ",";
                    values += currentValue + ",";
                }

                fields = fields.Substring(0, fields.Length - 1);
                values = values.Substring(0, values.Length - 1);

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        //  Purpose:        extract fields and their values from a dictionary and return them separated with comma delimiter between them
        //  Input:          fieldsList
        //                  recordFieldTypes
        //                  [out] fields    
        //                  [out] values    
        //                  [out] result
        //  Output:         true / false
        private bool ExtractFields(List<string> fieldsList,
                                   out string fields,
                                   out string result)
        {
            result = string.Empty;
            fields = string.Empty;

            try
            {
                if ((fieldsList == null) || (fieldsList.Count == 0))
                {
                    result = "Fields List Is Null Or Empty";

                    return false;
                }

                foreach (string currentField in fieldsList)
                {
                    fields += currentField + ",";
                }

                fields = fields.Substring(0, fields.Length - 1);

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        //  Purpose:        extract tables fields and values structures from CSV file
        //  Input:          tableFieldsTypesCsvPath 
        //                  tableName    
        //                  [out] tables    
        //                  [out] result
        //  Output:         true / false

        // Types: 
        //  character varying(n), varchar(n)	variable-length with limit
        //  character(n), char(n)	            fixed-length, blank padded
        //  text	                            variable unlimited length
        //
        //  smallint	        2 bytes	    small-range integer	-32768 to +32767
        //  integer	            4 bytes	    typical choice for integer	-2147483648 to +2147483647
        //  bigint	            8 bytes	    large-range integer	-9223372036854775808 to +9223372036854775807
        //  decimal	            variable	user-specified precision, exact	up to 131072 digits before the decimal point; up to 16383 digits after the decimal point
        //  numeric	            variable	user-specified precision, exact	up to 131072 digits before the decimal point; up to 16383 digits after the decimal point
        //  real	            4 bytes	    variable-precision, inexact	6 decimal digits precision
        //  double precision	8 bytes	    variable-precision, inexact	15 decimal digits precision
        //  smallserial	        2 bytes	    small autoincrementing integer	1 to 32767
        //  serial	            4 bytes	    autoincrementing integer	1 to 2147483647
        //  bigserial	        8 bytes	    large autoincrementing integer	1 to 9223372036854775807
        //
        //  timestamp [ (p) ] [ without time zone ]	8 bytes	    both date and time (no time zone)	4713 BC	294276 AD	1 microsecond / 14 digits
        //  timestamp [ (p) ] with time zone	    8 bytes	    both date and time, with time zone	4713 BC	294276 AD	1 microsecond / 14 digits
        //  date	                                4 bytes	    date (no time of day)	4713 BC	5874897 AD	1 day
        //  time [ (p) ] [ without time zone ]	    8 bytes	    time of day (no date)	00:00:00	24:00:00	1 microsecond / 14 digits
        //  time [ (p) ] with time zone	            12 bytes	times of day only, with time zone	00:00:00+1459	24:00:00-1459	1 microsecond / 14 digits
        //  interval [ fields ] [ (p) ]	            16 bytes	time interval	-178000000 years	178000000 years	1 microsecond / 14 digits
        //
        //  boolean	            1 byte	    state of true or false

        private bool ExtractTableFieldsTypes(string tableFieldsTypesCsvPath, string tableName, out Table table, out string result)
        {
            result = string.Empty;

            table = null;

            try
            {
                if (string.IsNullOrEmpty(tableFieldsTypesCsvPath))
                {
                    result = "Path To CSV File Is Null Or Empty";

                    return false;
                }

                if (string.IsNullOrEmpty(tableName))
                {
                    result = "Table Name Is Null Or Empty";

                    return false;
                }

                if (tableFieldsTypesCsvPath.Substring(tableFieldsTypesCsvPath.Length - 2, 1) != "\\")
                {
                    tableFieldsTypesCsvPath += "\\";
                }

                tableFieldsTypesCsvPath += tableName + CSV_FILE_EXTENSION;

                if (!File.Exists(tableFieldsTypesCsvPath))
                {
                    result = "File[" + tableFieldsTypesCsvPath + "] Does Not Exist";

                    return false;
                }

                List<List<string>> fieldList;
                if (!Utils.ReadFromCsvFile(tableFieldsTypesCsvPath, out fieldList, out result))
                {
                    return false;
                }

                if ((fieldList == null) || (fieldList.Count == 0))
                {
                    result = "No Fields For Table '" + tableName + "'";

                    return false;
                }

                table = new Table(tableName);

                int count = 1;
                foreach (List<string> currentField in fieldList)
                {
                    if ((currentField != null) && ((currentField.Count == NUMBER_OF_FIELD_PROPERTIES) || (currentField.Count == NUMBER_OF_FIELD_PROPERTIES + 1)))
                    {
                        string fieldName;
                        string fieldType;

                        fieldName = currentField[0];

                        if ((currentField.Count == (NUMBER_OF_FIELD_PROPERTIES + 1)) && (currentField[1].ToLower().Contains("identity")))
                        {
                            fieldType = $"{currentField[1]},{currentField[2]}";
                        }
                        else
                        {
                            fieldType = currentField[1];
                        }

                        if (!table.AddField(fieldName, fieldType, out result))
                        {
                            result += Environment.NewLine + result;
                        }
                    }
                    else
                    {
                        result += Environment.NewLine + "Current Field, Line " + count + " In File Is Null Or Wrong Number Of Parameters";
                    }

                    count++;
                }

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        //  Purpose:        create SQL conditions like 'WHERE X=2 AND Y=3 ....'
        //  Input:          fieldValue 
        //                  [out] sqlConditions   
        //                  [out] result
        //  Output:         true / false
        private bool CreateSqlConditions(Dictionary<string, string> fieldValue, out string sqlConditions, out string result)
        {
            result = string.Empty;
            sqlConditions = string.Empty;

            try
            {
                if ((fieldValue == null) || (fieldValue.Count == 0))
                {
                    return true;
                }

                sqlConditions = " WHERE ";

                foreach (KeyValuePair<string, string> keyValuePair in fieldValue)
                {
                    sqlConditions += keyValuePair.Key + " = " + keyValuePair.Value + " AND ";
                }

                sqlConditions = sqlConditions.Substring(0, sqlConditions.Length - 4);

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        //  Purpose:        comment field value. xyz ==> 'xyz'
        //  Input:          [ref] fieldValue 
        //                  [out] result
        //  Output:         true / false
        private bool CommentFieldValue(ref string fieldValue, out string result)
        {
            result = string.Empty;

            if (string.IsNullOrEmpty(fieldValue))
            {
                result = "Field Value Is Null Or Empty";

                return false;
            }

            fieldValue = "'" + fieldValue + "'";

            return true;
        }

        //  Purpose:        comment field value. xyz ==> 'xyz'
        //  Input:          tablename
        //                  [ref] fieldValue 
        //                  [out] result
        //  Output:         true / false
        private bool CommentFieldsValues(string tablename, ref Dictionary<string, string> fieldValue, out string result)
        {
            result = string.Empty;

            try
            {
                if (fieldValue == null)
                {
                    result = "Field Value Is Null Or Empty";

                    return false;
                }

                Dictionary<string, string> fieldsValuesToModify = new Dictionary<string, string>();

                foreach (KeyValuePair<string, string> keyValuePair in fieldValue)
                {
                    string field = keyValuePair.Key;
                    string value = keyValuePair.Value;

                    ColumnType columnType;
                    if (!GetColumnType(tablename, field, out columnType, out result))
                    {
                        continue;
                    }


                    if ((columnType == ColumnType.String) || (columnType == ColumnType.DateTime))
                    {
                        fieldsValuesToModify.Add(field, value);
                    }
                }

                foreach (KeyValuePair<string, string> keyValuePair in fieldsValuesToModify)
                {
                    string field = keyValuePair.Key;
                    string value = keyValuePair.Value;

                    if (!CommentFieldValue(ref value, out result))
                    {
                        continue;
                    }

                    fieldValue[field] = value;
                }

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        #endregion

        #region Event Handlers

        //  Purpose:        throw 'message' to whom registered on the event ContextRepositoryDatabaseMessage
        //  Input:          message 
        //  Output:         none
        private void OnContextRepositoryDatabaseMessage(string message)
        {
            if (RepositoryDatabaseMessage != null)
            {
                RepositoryDatabaseMessage(message, null);
            }
        }

        #endregion
    }
}
