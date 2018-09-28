using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using SimpleWifi;


namespace WifiForms
{
 public  class WifiConfig
{
      public static Wifi wifi;
      public string AccessPointName { get; set; }
      public string Password { get; set; }



      public WifiConfig()
        {
            Initialize();
        }
      public void Initialize()
      {
        wifi = new Wifi();
      }

      private bool ConnectWifi(AccessPoint ap, string passwrod)
      {
          AuthRequest autherequest = new AuthRequest(ap);
          autherequest.Password = passwrod;

          return ap.Connect(autherequest);
      }

      public int GetSignal()
      {
          AccessPoint aplist = wifi.GetAccessPoints().Find(x => x.Name == AccessPointName);

          if (wifi.ConnectionStatus == WifiStatus.Connected && aplist.Name == AccessPointName)
          {
              return int.Parse(aplist.SignalStrength.ToString());
          }
          else
          {
              return 0;
          
          }
      }


      public bool ConnectWifi()
      {

          AccessPoint aplist = wifi.GetAccessPoints().Find(x => x.Name == AccessPointName);
          if (ConnectWifi(aplist, Password))
          {
              return true;

          }
          else
          {
              return false;
          }
      }


}
}
