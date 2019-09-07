using System;
using System.Collections.Generic;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace GradeBook
{
  class TwiML
  {
    public static void Send(List<double> args)
    {
      DotNetEnv.Env.Load("./src/GradeBook/.env");
      string accountSid = DotNetEnv.Env.GetString("ACCOUNT_SID");
      string authToken = DotNetEnv.Env.GetString("AUTH_TOKEN");

      var kidStats = "";
      args.ForEach(grade =>
      {
        kidStats += $"| {grade.ToString()} ";
      });
      TwilioClient.Init(accountSid, authToken);

      var message = MessageResource.Create(
          body: $"Your child's first grades are {kidStats}|\n\n",
          from: new Twilio.Types.PhoneNumber(DotNetEnv.Env.GetString("FROM")),
          to: new Twilio.Types.PhoneNumber(DotNetEnv.Env.GetString("TO"))
      );

      Console.WriteLine($"Message SID: {message.Sid}");
    }
  }
}