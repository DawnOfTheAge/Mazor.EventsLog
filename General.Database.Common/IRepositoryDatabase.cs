using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using General.Database.Common;

namespace General.Database.Common
{
    public interface IRepositoryDatabase
    {
        event EventHandler RepositoryDatabaseMessage;

        bool OpenDb(OpenDatabaseParameters databaseParameters, out string result);
        bool CloseDb(out string result);
        bool IsConnected(out string result);

        bool Insert(string tableName, Dictionary<string, string> recordFields, out string newId, out string result);
        bool Insert(string tableName, 
                    Dictionary<string, string> recordFields, 
                    Dictionary<string, Type> recordFieldTypes, 
                    out string newId, 
                    out string result);
        bool Update(string tableName,
                    string keyField,
                    Type keyFieldType,
                    string keyFieldValue,
                    string targetField,
                    Type targetFieldType,
                    string targetFieldNewValue,
                    out string result);
        bool Retrieve(string table, Dictionary <string, string> filter, out List<List<string>> lContextRepositoryRecord, out string result);
        bool Remove(string table, string field, Type fieldType, string value, out string result);
        bool RecordExists(string table, string field, Type fieldType, string value, out string result);

        int Sum(string tableName, string fieldName, Type fieldType, string fieldValue, string accumulationField, out string result);
        int Count(string tableName, string fieldName, Type fieldType, string fieldValue, out string result);
        bool Max(string tableName, List<string> recordFields, string fieldName, out List<string> record, out string result);
        bool Min(string tableName, List<string> recordFields, string fieldName, out List<string> record, out string result);
        bool Distinct(string tableName, string idField, out List<string> distictList, out string result);
        List<string> GetBy(string tableName, Dictionary<string, string> fieldValue, List<string> wantedField, out string result);

        bool Query(string query, out List<List<string>> records, out string result);
        bool NonQuery(string nonQuery, out string result);
    }
}
