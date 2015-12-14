using System;
using System.ServiceModel;
using System.Collections.Generic;

namespace Server
{
    [ServiceContract]
    public interface IDataBase
    {
        [OperationContract]
        int Authorizate(string username, string password);

        [OperationContract]
        int Registration(string username, string password, string firstname, string secondname, string programmingLanguage);

        [OperationContract]
        List<int> GetUserFriends(int idUser);

        [OperationContract]
        string[] GetUser(int idUser);

        [OperationContract]
        string[] GetUserByLogin(string login);

        [OperationContract]
        List<string> AnswerCheck(int id, string source);

        [OperationContract]
        Dictionary<int, string[]> TaskList();

        [OperationContract]
        int AddTask(params string[] task);

        [OperationContract]
        void SendMessage(int firstid, int secondid, string message);

        [OperationContract]
        string GetMessage(int firstid, int secondid);

        [OperationContract]
        void DeleteFriend(int first_id, int second_id);

        [OperationContract]
        void AddFriend(int first_id, int second_id);
    }
}
