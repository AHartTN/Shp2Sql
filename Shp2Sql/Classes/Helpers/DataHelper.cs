using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shp2Sql.Classes.Helpers
{
    using System.Data;
    using System.Reflection;

    public class DataHelper
    {
        public static DataTable CreateDataTable<T>(IEnumerable<T> list)
        {
            Type type = typeof(T);
            var properties = type.GetProperties();

            DataTable dataTable = new DataTable();
            foreach (PropertyInfo info in properties)
                dataTable.Columns.Add(new DataColumn(info.Name, info.PropertyType));

            foreach (T entity in list)
            {
                object[] values = new object[properties.Length];
                for (int i = 0; i < properties.Length; i++)
                    values[i] = properties[i].GetValue(entity);
                dataTable.Rows.Add(values);
            }

            return dataTable;
        }
    }
}
