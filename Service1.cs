using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EstadoBateria
{
    public partial class EstadoBateria : ServiceBase
    {
        public EstadoBateria()
        {
            InitializeComponent();

            eventLog1 = new System.Diagnostics.EventLog();
            if (!System.Diagnostics.EventLog.SourceExists("EstadoBateria"))
            {
                System.Diagnostics.EventLog.CreateEventSource("EstadoBateria", "Application");
            }

            eventLog1.Source = "EstadoBateria";
            eventLog1.Log = "Application";
        }

        protected override void OnStart(string[] args)
        {
            eventLog1.WriteEntry("EstadoBateria Service Started", EventLogEntryType.Information);
        }

        protected override void OnStop()
        {
            eventLog1.WriteEntry("EstadoBateria Service Stopped", EventLogEntryType.Information);
        }

        private void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            string porcentaje;

            porcentaje = (SystemInformation.PowerStatus.BatteryLifePercent * 100).ToString() + "%";

            eventLog1.WriteEntry("Porcentaje actual de la bateria: " + porcentaje, EventLogEntryType.Information);
        }
    }
}
