using System;

namespace UChat.ChatEngine
{
	public interface IChatEngine
	{
		/// <summary>
		/// HTML Formatted user list
		/// </summary>
		string UserList
		{
			get;
		}
		/// <summary>
		/// Get the list of currently
		/// known users
		/// </summary>
		string[] Users
		{
			get;
		}
		/// <summary>
		/// Get the current buffer text
		/// </summary>
		string BufferText
		{
			get;
		}
		/// <summary>
		/// Check to see if a given user
		/// exists based on a guid
		/// </summary>
		bool GuidExists( string guid );
		/// <summary>
		/// Check to see if a given user 
		/// exists already
		/// </summary>
		bool UserExists( string user );
		/// <summary>
		/// Add a user to the chat group
		/// </summary>
		void AddUser( string guid, string user );
		/// <summary>
		/// Ping the chat engine to indicate
		/// you are still there
		/// </summary>
		void Ping( string user );
		/// <summary>
		/// Add text to the chat buffer
		/// </summary>
		void AddText( string guid, string text );
		/// <summary>
		/// Remove a user
		/// </summary>
		void Remove( string user, string password );
	}
}
