using Serv.IniFile;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Serv.Connection
{
    /// <summary>
    /// Структура состояний подключения к базе данных
    /// </summary>
    public enum enumDatabaseConnectionsState
    {
        isNull = -1,
        Close = 0,
        Open = 1,
        PingFailed = 2
    }

    public class ClassSQLDatabase
    {
        /// <summary>
        /// Возвращает Connection
        /// </summary>
        public SqlConnection databaseConnection;

        // IP-адрес сервера БД. Выцарапываем из строки подключения
        public string strIPAddressServer = null;

        /// <summary>
        /// Возвращает состояние подключения к базе данных
        /// </summary>
        public enumDatabaseConnectionsState databaseConnectionState;

        public ClassSQLDatabase()
        { 
            string strProjectName = System.Reflection.Assembly.GetEntryAssembly().GetName().Name;
            // Путь к .exe
            string strBaseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string connetionString = null;
            string s = strBaseDirectory + strProjectName + ".ini";
            ClassIniFiles classIniFiles = new ClassIniFiles(@s);
            String inStrPath = classIniFiles.ReadString("Common", "DataBase", "");
            connetionString = inStrPath;
            databaseConnection = new SqlConnection(connetionString);
            databaseConnectionState = enumDatabaseConnectionsState.Close;

        }


        public void CloseDataBase()
        {
            databaseConnection.Close();
        }
        public void OpenDataBase()
        {
             databaseConnection.Open();

        }
        public void OpenCloseDataBase(bool flOpen)
        {
            if (databaseConnection == null)
                return;

            databaseConnectionState = enumDatabaseConnectionsState.Open;
            try
            {
                if (flOpen == true)
                    databaseConnection.Open();
                else
                    databaseConnection.Close();
            }
            catch
            {
                databaseConnectionState = enumDatabaseConnectionsState.Close;
            }

            if (databaseConnection.State == ConnectionState.Closed)
            {
                databaseConnectionState = enumDatabaseConnectionsState.Close;
            }

        }

        // Деструктор
        ~ClassSQLDatabase()
        {
            this.OpenCloseDataBase(false);
        }
    }

    public class ClassDataSet
    {
        private SqlCommand QueryCommand;
        private SqlConnection mySqlConnection;

        public ClassDataSet(SqlConnection inSqlConnection)
        {
            mySqlConnection = inSqlConnection;
        }

        /// <summary>
        /// Заполняет table[iTableIndex] набора данных inDataSet записями из запроса QueryCommand 
        /// </summary>
        /// <param name="inDataSet">Набор данных, в который нужно поместить записи</param>
        /// <param name="iTableIndex">Индекс таблицы, в которую нужно поместить записи. Обычно = 0</param>
        /// <param name="strSQL">текст SQL-запроса</param>
        public void FillDataSet(DataSet inDataSet, int iTableIndex, string strSQL)
        {
            Cursor OldCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                SqlTransaction transaction = mySqlConnection.BeginTransaction();
                QueryCommand = new SqlCommand(strSQL, mySqlConnection, transaction);
                QueryCommand.Transaction.Commit();
                SqlDataAdapter adapter = new SqlDataAdapter(QueryCommand);
                adapter.Fill(inDataSet.Tables[iTableIndex]);
                
                
            }
            finally
            {
                Cursor.Current = OldCursor;
            }
        }

        public void PostDataSet(string strSQL)
        {
            Cursor OldCursor = Cursor.Current;

            try
            {
                SqlTransaction transaction = mySqlConnection.BeginTransaction();
                QueryCommand = new SqlCommand(strSQL, mySqlConnection, transaction);
                QueryCommand.ExecuteNonQuery();
                QueryCommand.Transaction.Commit();
                SqlDataAdapter adapter = new SqlDataAdapter(QueryCommand);

            }
            finally
            {
                Cursor.Current = OldCursor;
            }
        }

      
    }
}
