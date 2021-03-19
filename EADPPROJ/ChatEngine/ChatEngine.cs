using System;
using System.Text;
using System.Threading;
using System.Collections;
using System.Collections.Specialized;
////////////5///1///a///s///p///x/////////////////////
namespace UChat.ChatEngine
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“ChatEngine”的 XML 注释
	public class ChatEngine : IChatEngine
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“ChatEngine”的 XML 注释
	{
		const string msg = "<li class=\"{0}\">{1}</li>\r\n";
		const string userlistfmt = "<li>{0}</li>\r\n";
		
		const string serverstyle = "servermsg";	
		const string userstyle = "usermsg";
		const string actionstyle = "actionmsg";
		
		const string timeoutfmt = "User {0} timed out";
		const string textlimitfmt = "{0}, your message was {1} characters long.  The limit is {2} characters.";
		const string nickinusefmt = "{0} a user with this nick already exists";
		const string joinedfmt = "User {0} has joined";
		const string nickfmt = "{0} is now known as {1}";
		const string killfmt = "<strong>User {0} has been terminated!</strong>";
		const string clearfmt = "<strong>User {0} has cleared all chat log!</strong>";
		const string unknowcmdfmt = "<strong>User {0} : Unknow command</strong>";
		const string mefmt = "{0} {1}";
		const string txtfmt = "{0}: {1}";

		const long timerdelay = 300000;
		const int maxbuffer = 20;
		const int textlimit = 100;

		Timer timer;

		Hashtable users;
		StringCollection chat;
		StringCollection pings;

		object syncRoot = new object();
		/// <summary>
		/// Default constructor
		/// </summary>
		public ChatEngine()
		{
			users	= new Hashtable();
			chat	= new StringCollection();
			pings	= new StringCollection();

			TimerCallback OnTimerTick = new TimerCallback( TimerTick );
			timer = new Timer( OnTimerTick, null, timerdelay, timerdelay );
		}

        //5~1~a~s~p~x
		/// <summary>
		/// Check for pinged out users
		/// </summary>
		private void TimerTick( object state )
		{
			lock( syncRoot )
			{
				string[] current = new string[ users.Keys.Count ];
				users.Keys.CopyTo( current, 0 );

				foreach( string guid in current )
				{
					if( !pings.Contains( guid ) )
					{				
						chat.Add( 
							this.MakeServerMessage(
								string.Format( timeoutfmt, users[ guid ].ToString() ) 
							)
						);

						users.Remove( guid );
					}
				}
				pings.Clear();
			}
		}
		/// <summary>
		/// Gets the current list of
		/// users
		/// </summary>
		public string[] Users
		{
			get
			{
				string[] nicks = new string[ users.Count ];
				users.Values.CopyTo( nicks, 0 );
				return nicks;
			}
		}

		/// <summary>
		/// HTML Formatted user list
		/// </summary>
		public string UserList
		{
			get
			{
				StringBuilder sb = new StringBuilder();

				string[] nicks = new string[ users.Count ];
				users.Values.CopyTo( nicks, 0 );

				foreach( string user in nicks )
				{
					sb.Append( string.Format( userlistfmt, user ) );
				}

				return sb.ToString();
			}
		}
		/// <summary>
		/// Gets the current buffer of chat text
		/// </summary>
		public string BufferText
		{
			get
			{
				StringBuilder sb = new StringBuilder();

				foreach( string line in chat )
				{
					sb.Append( line );
				}

				return sb.ToString();
			}
		}
        //51-aspx
		/// <summary>
		/// Does a user exist based on a guid
		/// </summary>
		public bool GuidExists( string guid )
		{
			return users.ContainsKey( guid );
		}
		/// <summary>
		/// Checks to see if the current user 
		/// exists in the list
		/// </summary>
		public bool UserExists(string user)
		{
			return users.ContainsValue( user );
		}
		/// <summary>
		/// Adds a user to the list
		/// </summary>
		public void AddUser(string id, string user)
		{
			lock( syncRoot )
				if( !UserExists( user ) )
				{
					users.Add( id, user );
					pings.Add( id );
					
					chat.Add( 
						this.MakeServerMessage(
							string.Format( joinedfmt, user ) 
						)
					);
				}
		}

		/// <summary>
		/// Pings this chat server and keeps 
		/// a user alive
		/// </summary>
		public void Ping(string guid)
		{
			lock( syncRoot )
				pings.Add( guid );
		}

		/// <summary>
		/// Adds text to the buffer
		/// </summary>
		public void AddText(string guid, string text)
		{

			if( text.Trim().Length == 0 )
				return;

			if( text.Length > textlimit )
			{
				chat.Add(
					MakeServerMessage( 
						string.Format(
							textlimitfmt,
							users[ guid ].ToString(),
							text.Length,
							textlimit
						)
					)
				);
				return;
			}

            //5^1^a^s^p^x
			while( chat.Count > maxbuffer )
			{
				chat.RemoveAt( 0 );
			}

			if( !pings.Contains( guid ) )
			{
				pings.Add( guid );
			}

			chat.Add( 
				ParseText( users[ guid ].ToString(), text )
			);
		}

		/// <summary>
		/// Format the users chat depending on whether 
		/// a control command was supplied.
		/// </summary>
		private string ParseText( string user, string text )
		{
			if( text.StartsWith( "/me " ) )
			{
				return MakeActionMessage(
					string.Format( mefmt, user, text.Replace( "/me", string.Empty ) )
					);
			}

			if( text.StartsWith( "/admin " ) )
			{
				string command = text.Replace("/admin", string.Empty).Trim();
				string result = string.Empty;

				switch(command)
				{
					case "clear":
						chat.Clear();
						result = MakeServerMessage( 
							string.Format(clearfmt,	user)
							);
						break;
					default:
						result = MakeServerMessage( 
							string.Format(unknowcmdfmt,	user)
							);
						break;
				}
				return result;
			}

            //5%1%a%s%p%x
			if( text.StartsWith( "/nick " ) )
			{
				string newnick = text.Replace( "/nick", string.Empty ).Trim();
				
				if( UserExists( newnick ) )
				{
					return MakeServerMessage(
						string.Format( nickinusefmt, user )
						);
				}
				
				string[] keys = new string[ users.Count ];
				users.Keys.CopyTo( keys, 0 );

				foreach( string key in keys )
				{
					if( users[ key ].ToString() == user )
					{
						users[ key ] = newnick;
						return MakeServerMessage( 
							string.Format(nickfmt, user, newnick
							)
						);
					}
				}
				
			}

			return MakeUserMessage( 
				string.Format( txtfmt, user, text ) 
				);
		}
		/// <summary>
		/// Remove the user
		/// </summary>
		public void Remove( string user, string password )
		{
			//
			// TODO: Add your password here
			if( password != "Add password here!" )
				return;

			if( this.UserExists( user ) )
			{
				string[] keys = new string[ users.Count ];
				foreach( DictionaryEntry e in users )
				{
					if( e.Value.ToString() == user )
					{
						chat.Add( 
							this.MakeServerMessage(
								string.Format( killfmt, user ) 
							)
						);

						users.Remove( e.Key );
						return;
					}
				}
			}

			if( pings.Contains( user ) )
				pings.Remove( user );
		}
		/// <summary>
		/// Format a server message by wrapping
		/// text in a list item with the server
		/// css class selector
		/// </summary>
		private string MakeServerMessage( string text )
		{
			return string.Format( msg, serverstyle, text );
		}
		/// <summary>
		/// Format a user message by wrapping text
		/// in a list item with the user css class
		/// selector
		/// </summary>
		private string MakeUserMessage( string text )
		{
			return string.Format( msg, userstyle, text );
		}
		/// <summary>
		/// Format a user action message by wrapping text
		/// in a list item with the action css class
		/// selector
		/// </summary>
		private string MakeActionMessage( string text )
		{
			return string.Format( msg, actionstyle, text );
		}
	}
}
