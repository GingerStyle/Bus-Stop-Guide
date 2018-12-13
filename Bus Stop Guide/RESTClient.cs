using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bus_Stop_Guide
{
    //using this for if I wanted to expand this program later.
    //I will only be using the GET function for now.
    public enum httpwords
    {
        GET,
        POST,
        PUT,
        DELETE
    }

    //Class to handle the requests from the Metro Transit server
    class RESTClient
    {
        //getters and setters
        public string endPoint { get; set; }
        public httpwords httpFunction { get; set;}

        //constructor
        public RESTClient()
        {
            //creating the endpoint. This will change depending on what information I request
            endPoint = "";
            //setting the function to GET by default
            httpFunction = httpwords.GET;
        }

        //method to perform the GET request
        public string request()
        {
            //setting up the request
            string responseString = "";
            //getting the request method and converting it to a string
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);
            request.Method = httpFunction.ToString();

            //checking that a response was recieved
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        MessageBox.Show("Did not recieve a response from the server. Check your internet connection and please try again", "Response Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    //process the response
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        //making sure the response isn't empty
                        if (responseStream != null)
                        {
                            using (StreamReader reader = new StreamReader(responseStream))
                            {
                                //adding the response to responseString variable
                                responseString = reader.ReadToEnd();
                            }
                        }
                        else
                        {
                            System.Windows.Forms.MessageBox.Show("Response was empty. Please try again.", "Empty Response");
                        }
                    }

                }
            }
            catch (System.Net.WebException e)
            {
                Console.WriteLine(e.Message);
            }
            //returning the response
            return responseString;

        }
    }
}
