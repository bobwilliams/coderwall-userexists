using System;
using System.IO;
using System.Net;
using Gtk;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void OnBtnVerifyUserClicked (object sender, EventArgs e)
	{
		var user = txtUser.Text;
		var userURL = String.Format ("http://coderwall.com/{0}.json", user);

		if (String.IsNullOrEmpty(user)) {
			Console.WriteLine("Please specify a user name");
		} else
		{
			// Create a 'WebRequest' object with the specified url. 
			WebRequest myWebRequest = WebRequest.Create(userURL); 
			// Send the 'WebRequest' and wait for response.
			WebResponse myWebResponse = myWebRequest.GetResponse(); 
			using (var streamReader = new StreamReader(myWebResponse.GetResponseStream()))
			{
				var responseText = streamReader.ReadToEnd();
				//Now you have your response.
				//or false depending on information in the response 
				lblVerificationText.Text = responseText;
			}
		}
	}
}