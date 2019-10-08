using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1
{
    class Program
    {
        static void Main(string[] args)
        {
            // --content--zzzzzzzz
            // 1. user
            // 2. transfer
            // 3. order
            // 4. match
            // 5. util
            // 6. notes
        }

        #region user

        // UserAdd
        // UserExists
        // UserCheckPwd
        // UserLogin
        // UserChangePwd
        // UserIdFromUserName

        // takes validated userName and UserPwd
        // enters in to table user
        // name, pwd, status, joinDate
        // returns true if success
        public bool UserAdd(string userName, string userPwd)
        {
            // string for current datetime
            // string for sql query
            // string array for sql parameters
            // call 
            // DatabaseWriteOutput = DatabaseWrite( sqlQuery, sqlParameters )
            // if writeOutput != good
            //    return false
            // make rows on balance table for each currency
            // apply sign up bonus
            // return true
            return false;
        }


        // takes validated userName and userPwd
        // returns true if userName can login
        public bool UserLogin(string userName, string userPwd)
        {
            // bool UserCheckPwdOutput = UserCheckPwd( string userName, string userPwd )
            // optional if bool true add to login log
            // return UserCheckPwdOutput
            return false;
        }


        // takes validated userName and userPwd
        // if Pwd is equal and status is 'active'
        // return true
        public bool UserCheckPwd(string userName, string userPwd)
        {
            // string sql query
            // string[] sql parameters
            // select id from table user 
            // where userName == userName and 
            //    pwd == pwd and 
            //    status == 'active'
            // userRow[] == DatabaseRead( query, parameters ) 
            // if( userRow == null )
            //   return false
            // return true
            return false;
        }


        // takes validated userName, oldPwd, newPwd
        // returns true if success
        public bool UserChangePwd()
        {
            // bool UserCheckPwdOutput = UserCheckPwd( userName, oldPwd )
            // if UserCheckPwdOutput == false
            //    return false
            // string sql query = 
            // update in table where userName == userName
            // pwd = newPwd
            // string sql parameters { userName, newPwd }
            // DatabaseWriteOutput = DatabaseWrite( sqlQuery, sqlParameters )
            // return DatabaseWriteOutput
            return false;
        }


        // takes validated userName and returns it's Id as int
        // returns -1 for fail or not found
        public int UserIdFromUserName(string username)
        {
            // query = select id from user where userName = userName
            // dbRows[][] == DatabaseRead( query, parameters ) 
            // if( dbRows[][] == null )
            //   return -1
            // return dbRows[0][0]
            return -1;
        }
        #endregion

        #region transfer
        // BalanceAmount
        // BalanceAmountUsingId
        // CurrenyIdFromString
        // CurrencyList
        // SendAmount
        // SendAmountUsingId
        // SenderHasEnough
        // SendLogAdd
        // SendLogList


        // takes validated UserName and currencyName
        // returns amount as int of user's balance
        // returns -1 for fail
        public int BalanceAmount(string userName, string currencyName)
        {
            // int userId = UserIdFromUserName( userName )
            // if userId == -1
            //   return -1
            // int currencyId = currencyIdFromString( currencyName )
            // if currencyId == -1
            //   return -1
            // return BalanceAmountUsingId( userId, currencyId )
            return -1;
        }


        // takes validated UserId and currencyId
        // returns amount as int of user's balance
        // returns -1 for fail
        public int BalanceAmountUsingId(string userId, string currencyId)
        {
            // select amount from balance 
            // where currencyId == currencyId
            // and userId == userId
            // dbRows[][] == DatabaseRead( query, parameters ) 
            // if( dbRows[][] == null )
            //   return 0
            // return (int)dbRows[0][0]

            return -1;
        }


        // takes validated currency
        // returns -1 if currency does not exist
        public int currencyIdFromString(string currencyName)
        {
            // query = select id from currency where name = currencyName
            // dbRows[][] == DatabaseRead( query, parameters ) 
            // if( dbRows[][] == null )
            //   return -1
            // return dbRows[0][0]
            return -1;
        }

        // returns a 2d string array,
        // each currency has id and name
        // id is a string 
        // return null for fail
        public string[][] CurrencyList()
        {
            // select id name from currency 
            // parameters = []
            // dbRows[][] == DatabaseRead( query, parameters ) 
            // return dbRows
            return null;
        }


        // takes validated from, to, currency, amount
        // as strings
        // return false for fail,
        // error messages could be assigned to global variable
        public bool SendAmount(string userNameSend, string UserNameReceive,
            string currencyName, int amount)
        {
            // int userIdSend = UserIdFromUserName( userNameSend )
            // if userIdSend == -1
            //   return false
            // int userIdReceive = UserIdFromUserName( userNameSend )
            // if userIdReceive == -1
            //   return false
            // int currencyId = currencyIdFromString( currencyName )
            // if currencyId == -1
            //   return false
            // return SendAmountUsingId( userIdSend, userIdReceive, currencyId, amount )
            return false;
        }


        // takes validated from, to, currency, amount
        // as strings
        // return false for fail,
        // error messages could be assigned to global variable
        public bool SendAmountUsingId(int userIdSend, int UserIdReceive,
            int currencyId, int amount)
        {
            // does sender have enough balance
            // bool senderHasEnough = SenderHasEnough( userIdSend, currencyId, amount )
            // if senderHasEnough == false
            //   return false
            // DatabaseLock, if db locked already loop or fail
            // subtract amount from sender
            // add amount to receiver
            // add to SendLogAdd
            // DatabaseUnLock
            return false;
        }


        // does userId have equal or greater than amount
        // return true if yes 
        // return false if not enough or fail
        public bool SenderHasEnough(int senderId, int currencyId, int amount)
        {
            // get balance
            // BalanceAmountUsingId(string userId, string currencyId )
            // is balance greater than amount
            // if true 
            //   return true
            // return false
            return false;
        }

        // takes UserIdSend userIdReceive, currencyId, amount
        // adds datetime
        public bool SendLogAdd()
        {
            // insert into SendLog
            // senderId, receiverId, currencyId, amount, dateTime
            return false;
        }


        // option for name or id, startPos, resultAmount
        public string[][] SendLogList()
        {
            return null;
        }
        #endregion

        #region order
        // OrderAdd
        // OrderListByUser
        // OrderListByPair
        #endregion

        #region matching
        // MatchOrdersByPair
        // TradeLogAdd
        // TradeLogList
        #endregion

        #region util
        // ValidateString
        // DatabaseSelect
        // DatabaseWrite
        // DatabaseLock
        // DatabaseUnLock
        #endregion

        #region notes
        // [ optional ] UserList
        // [ optional ] hash passwords
        // [ optional ] store userId somewhere
        // [ optional ] make method getIdFromName( tableName, attributeName )
        // [ unclear ]  UserCheckPwd also checks status
        // validation and sql might change
        // set header
        #endregion

        #region database structure
        /*
        user
        currency
        balance
        send
        order
        trade
        keyvalue

        user
            Id
            Name
            Pwd
            Status
            Datetime

        currency
            Id
            Name

        balance --- note compound key not used
            Id
            user_Id
            currency_Id
            Amount

        send
            Id
            A_user_Id
            B_user_Id
            currency_Id
            Amount

        order
            Id
            user_Id
            Buysell
            A_currency_Id
            B_currency_Id
            Price
            Amount
            Datetime

        trade
            Id
            A_order_Id
            B_order_Id
            A_send_Id
            B_send_Id

        keyvalue
            Id
            user_Id
            Key
            Value
            Datetime
        */
        #endregion
    }

}
