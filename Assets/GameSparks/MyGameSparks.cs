using System;
using System.Collections.Generic;
using GameSparks.Core;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;

//THIS FILE IS AUTO GENERATED, DO NOT MODIFY!!
//THIS FILE IS AUTO GENERATED, DO NOT MODIFY!!
//THIS FILE IS AUTO GENERATED, DO NOT MODIFY!!

namespace GameSparks.Api.Requests{
	public class LogEventRequest_LOAD_AUDIO : GSTypedRequest<LogEventRequest_LOAD_AUDIO, LogEventResponse>
	{
	
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogEventResponse (response);
		}
		
		public LogEventRequest_LOAD_AUDIO() : base("LogEventRequest"){
			request.AddString("eventKey", "LOAD_AUDIO");
		}
		
		public LogEventRequest_LOAD_AUDIO Set_PLAYER_ID( string value )
		{
			request.AddString("PLAYER_ID", value);
			return this;
		}
		
		public LogEventRequest_LOAD_AUDIO Set_OBJECT( string value )
		{
			request.AddString("OBJECT", value);
			return this;
		}
		
		public LogEventRequest_LOAD_AUDIO Set_UPLOAD_ID( string value )
		{
			request.AddString("UPLOAD_ID", value);
			return this;
		}
	}
	
	public class LogChallengeEventRequest_LOAD_AUDIO : GSTypedRequest<LogChallengeEventRequest_LOAD_AUDIO, LogChallengeEventResponse>
	{
		public LogChallengeEventRequest_LOAD_AUDIO() : base("LogChallengeEventRequest"){
			request.AddString("eventKey", "LOAD_AUDIO");
		}
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogChallengeEventResponse (response);
		}
		
		/// <summary>
		/// The challenge ID instance to target
		/// </summary>
		public LogChallengeEventRequest_LOAD_AUDIO SetChallengeInstanceId( String challengeInstanceId )
		{
			request.AddString("challengeInstanceId", challengeInstanceId);
			return this;
		}
		public LogChallengeEventRequest_LOAD_AUDIO Set_PLAYER_ID( string value )
		{
			request.AddString("PLAYER_ID", value);
			return this;
		}
		public LogChallengeEventRequest_LOAD_AUDIO Set_OBJECT( string value )
		{
			request.AddString("OBJECT", value);
			return this;
		}
		public LogChallengeEventRequest_LOAD_AUDIO Set_UPLOAD_ID( string value )
		{
			request.AddString("UPLOAD_ID", value);
			return this;
		}
	}
	
	public class LogEventRequest_SAVE_AUDIO : GSTypedRequest<LogEventRequest_SAVE_AUDIO, LogEventResponse>
	{
	
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogEventResponse (response);
		}
		
		public LogEventRequest_SAVE_AUDIO() : base("LogEventRequest"){
			request.AddString("eventKey", "SAVE_AUDIO");
		}
		
		public LogEventRequest_SAVE_AUDIO Set_PLAYER( string value )
		{
			request.AddString("PLAYER", value);
			return this;
		}
		
		public LogEventRequest_SAVE_AUDIO Set_UPLOAD_ID( string value )
		{
			request.AddString("UPLOAD_ID", value);
			return this;
		}
	}
	
	public class LogChallengeEventRequest_SAVE_AUDIO : GSTypedRequest<LogChallengeEventRequest_SAVE_AUDIO, LogChallengeEventResponse>
	{
		public LogChallengeEventRequest_SAVE_AUDIO() : base("LogChallengeEventRequest"){
			request.AddString("eventKey", "SAVE_AUDIO");
		}
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogChallengeEventResponse (response);
		}
		
		/// <summary>
		/// The challenge ID instance to target
		/// </summary>
		public LogChallengeEventRequest_SAVE_AUDIO SetChallengeInstanceId( String challengeInstanceId )
		{
			request.AddString("challengeInstanceId", challengeInstanceId);
			return this;
		}
		public LogChallengeEventRequest_SAVE_AUDIO Set_PLAYER( string value )
		{
			request.AddString("PLAYER", value);
			return this;
		}
		public LogChallengeEventRequest_SAVE_AUDIO Set_UPLOAD_ID( string value )
		{
			request.AddString("UPLOAD_ID", value);
			return this;
		}
	}
	
}
	

namespace GameSparks.Api.Messages {


}
