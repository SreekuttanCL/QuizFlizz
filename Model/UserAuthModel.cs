﻿using System;
using QuizApp.ENUMS;

namespace QuizApp.Model
{
    public class UserAuthInfoObject
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public AuthType AuthType { get; set; }
        public string AwsCode { get; set; }
        //used for token refresh
        public string IdToken { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime TokenIssued { get; set; }
        public DateTime TokenExpire { get; set; }
    }
}
