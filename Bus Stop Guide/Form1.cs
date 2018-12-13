using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bus_Stop_Guide
{
    public partial class mainfrm : Form
    {
        //variables to hold route and direction
        string ROUTE = "";
        string DIRECTION = "";
        string DIRECTION_CODE = "";
        string STOPID = "";

        //list of urls to make requests
        private string formatLine = "?format=json";
        private string routeUrl = "http://svc.metrotransit.org/NexTrip/Routes";
        private string directionUrl = "http://svc.metrotransit.org/NexTrip/Directions/";
        private string stopsUrl = "http://svc.metrotransit.org/NexTrip/Stops/";
        private string departTimeUrl = "http://svc.metrotransit.org/NexTrip/";

        //creating restClient object to send commands to web server when needed
        RESTClient restClient = new RESTClient();

        public mainfrm()
        {
            InitializeComponent();

            //get bus routes and popluate the busRoutecmb
            restClient.endPoint = routeUrl + formatLine;
            string response = restClient.request();

            //show me what was returned for debug puposes
            Console.WriteLine(response);

            //splitting into routes
            string[] splitByRoute = response.Split('}');
            
            //extracting route number from elements in splitByRoute
            List<string> extractedRouteNums = new List<string>();
            List<string> routes = new List<string>();
            foreach (string element in splitByRoute)
            {
                string[] routeParts = element.Split(',');
                foreach (string routePart in routeParts)
                {
                    if (routePart.Contains("Route"))
                    {
                        routes.Add(routePart);
                    }
                }
            }
            foreach (string route in routes)
            {
                string newRoute = route.Replace("\"Route\":\"", "");
                newRoute = newRoute.Replace("\"", "");
                extractedRouteNums.Add(newRoute);
            }

            //add repsonse to busRoutecmb
            busRoutecmb.DataSource = extractedRouteNums;

        }

        //method to control what happens after the user selects a bus route
        private void busRoutecmb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //enable directioncmb to enable the user to then pick a route direction
            directioncmb.Enabled = true;
            
            //get route directions for selected route
            string routeNum = busRoutecmb.GetItemText(busRoutecmb.SelectedItem);
            restClient.endPoint = directionUrl + routeNum + formatLine;
            string response = restClient.request();
            //write response to console for debugging purposes
            Console.WriteLine(response);

            //looking at which directions the route goes and populating directioncmb
            List<string> directions = new List<string>();
            if(response.Contains("1") == true){ directions.Add("South"); }
            if(response.Contains("2") == true){ directions.Add("East"); }
            if(response.Contains("3") == true){ directions.Add("West"); }
            if(response.Contains("4") == true){ directions.Add("North"); }
            //adding the found directions to the combobox
            directioncmb.DataSource = directions;
        }

        //method to control what happens after the user selects the bus route direction
        private void directioncmb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //enable stopcmb
            stopcmb.Enabled = true;

            //variables to hold the route and direction
            ROUTE = busRoutecmb.GetItemText(busRoutecmb.SelectedItem);
            DIRECTION = directioncmb.GetItemText(directioncmb.SelectedItem);

            //get directions code
            if (DIRECTION == "South") { DIRECTION_CODE = "1"; }
            if (DIRECTION == "East") { DIRECTION_CODE = "2"; }
            if (DIRECTION == "West") { DIRECTION_CODE = "3"; }
            if (DIRECTION == "North") { DIRECTION_CODE = "4"; }
            //request the information
            restClient.endPoint = stopsUrl + ROUTE + "/" + DIRECTION_CODE + formatLine;
            string response = restClient.request();
            response = response.Trim('[', ']');
            //printing result to console for debugging purposes
            Console.WriteLine(response);

            //formatting response
            List<string> stops = new List<string>();
            string[] splitByStop = response.Split('}');
            foreach (string element in splitByStop)
            {
                string stop = element.Trim(new Char[] { '{', '}' });
                stop = stop.Trim(',');
                stop = stop.Trim('{');
                stop = stop.Replace("\"Text\":\"", "");
                stop = stop.Replace("\"", " ");
                stop = stop.Replace("Value", "Stop ID");
                //add formatted elements to the List
                stops.Add(stop);

            }

            stopcmb.DataSource = stops;
            
        }

        //method to control what happens after the user selects their stop
        private void stopcmb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //enable the Show Times button
            showTimesbtn.Enabled = true;

            //get the selected bus stop
            string stopString = stopcmb.GetItemText(stopcmb.SelectedItem);

            //extract stop id from the bust stop string
            string[] stopData = stopString.Split(',');
            stopData[1] = stopData[1].Replace(" Stop ID : ", "");
            STOPID = stopData[1];
        }

        //method to control what happens when you press the show times button
        private void showTimesbtn_Click(object sender, EventArgs e)
        {
            //clear text box
            resulttxt.Clear();

            //making request for the departure time of requested stop
            Console.WriteLine(ROUTE + " " + DIRECTION_CODE + " " + STOPID);
            restClient.endPoint = departTimeUrl + ROUTE + "/" + DIRECTION_CODE + "/" + STOPID + formatLine;
            string response = restClient.request();
            //show what was returned on console
            Console.WriteLine(response);

        }

    }
}
