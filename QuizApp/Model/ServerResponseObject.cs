using System;
using QuizApp.ENUMS;

namespace QuizApp.Model
{
    public class ServerResponseObject
    {
        public ServerReplyStatus status;
        public string error;
        public string message;
        public string data;
    }
}
