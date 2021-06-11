using System;
using System.Collections.Generic;
using System.Text;

namespace CommonHelpers.Response
{
	public sealed class ResponseInfo
	{

		public static readonly ResponseInfo SUCCESS = new ResponseInfo("SUCCESS", 200, "Success");
		public static readonly ResponseInfo ERROR = new ResponseInfo("INTERNALSERVERERROR", 500, "Error");
		public static readonly ResponseInfo BAD_REQUEST = new ResponseInfo("BAD_REQUEST", 400, "Bad Request");
		public static readonly ResponseInfo NOT_FOUND = new ResponseInfo("NOT_FOUND", 404, "Not Found");

		public int StatusCode
		{
			get
			{
				return statusCode;
			}
		}

		public string ResponseMessage
		{
			get
			{
				return statusMessage;
			}
		}

		public bool Error
		{
			get
			{
				return error;
			}
		}
		public enum InnerEnum
		{
			SUCCESS,
			ERROR,
			BAD_REQUEST,
			NOT_FOUND
		}


		private readonly int statusCode;

		private readonly string statusMessage;

		private readonly bool error;
		public ResponseInfo(string statusname, int statusCode, string responseMessage)
		{
			this.error = true;
			this.statusCode = statusCode;
			this.statusMessage = responseMessage;
			if (statusCode == 200)
				this.error = false;
		}

		#region ResponseMessage
		public class ResponseStatusMessage
		{

			public static readonly ResponseStatusMessage SUCCESS_MESSAGE = new ResponseStatusMessage(200, false, "Success");
			public static readonly ResponseStatusMessage ERROR_MESSAGE = new ResponseStatusMessage(500, true, "Internal Server Error");
			public static readonly ResponseStatusMessage BAD_REQUEST_MESSAGE = new ResponseStatusMessage(400, true, "Bad Request");
			public static readonly ResponseStatusMessage NOT_FOUND_MESSAGE = new ResponseStatusMessage(404, true, "Not Found");
			public static readonly string ErrorMessage = "404 Not Found";
			public static readonly string MessageOkay = "200 Ok";

			public int statuscode
			{
				get
				{
					return _statuscode;
				}
			}
			public bool error
			{
				get
				{
					return _error;
				}
			}
			public string message
			{
				get
				{
					return _message;
				}
			}

			private readonly int _statuscode;
			private readonly bool _error;
			private readonly string _message;
			public ResponseStatusMessage(int _statuscode, bool _error, string _message)
			{
				this._statuscode = _statuscode;
				this._error = _error;
				this._message = _message;
			}
		}
		#endregion

	}


}
