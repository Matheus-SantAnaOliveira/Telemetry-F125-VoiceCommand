using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1VoiceDashboardWorker.Models
{
    public class Commands
    {
        static readonly string positionsDashbord = "http://localhost:5601/app/dashboards#/view/f6f18056-96f1-42ab-8cdc-a80e62b3f807?_g=(filters:!(),refreshInterval:(pause:!f,value:2000),time:(from:now-15m,to:now))";
        static readonly string raceData = "http://localhost:5601/app/dashboards#/view/a4bf5f3f-e3b7-42f3-b897-4334572b4ebc?_g=(filters:!(),refreshInterval:(pause:!f,value:2000),time:(from:now-15m,to:now))";
        static readonly string lapTime = "http://localhost:5601/app/dashboards#/view/fa2915b0-d5f2-4a05-a05d-42d707d3d7a1?_g=(filters:!(),refreshInterval:(pause:!t,value:60000),time:(from:now-15m,to:now))";
        static readonly string controlData = "http://localhost:5601/app/dashboards#/view/cfc3e072-38fb-4840-a79d-db16f59f2f66?_g=(filters:!(),refreshInterval:(pause:!f,value:2000),time:(from:now-15m,to:now))";
        static readonly string wingDamage = "http://localhost:5601/app/dashboards#/view/6fbc80fb-225e-43a6-93be-0a6b9c744e6f?_g=(filters:!(),refreshInterval:(pause:!f,value:2000),time:(from:now-15m,to:now))";
        static readonly string tireData = "http://localhost:5601/app/dashboards#/view/db8ae0ee-19d5-4ac2-a1d0-aef027479d27?_g=(filters:!(),refreshInterval:(pause:!t,value:60000),time:(from:now-15m,to:now))";
        static readonly string fuelData = "http://localhost:5601/app/dashboards#/create?_g=(filters:!(),refreshInterval:(pause:!t,value:60000),time:(from:now-24h%2Fh,to:now))";

        static readonly string closeBrowser = "FECHAR_NAVEGADOR";
        static readonly string cleanCommand = "LIMPAR";
        static readonly string switchMonitor = "ALTERAR_MONITOR";
        static readonly string startTelemetry = "INICIAR_TELEMETRIA";

        static readonly string stopTelemetry = "PARAR_TELEMETRIA";
        public static readonly Dictionary<string, string> CommandsUrl = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            ["posição"] = positionsDashbord,
            ["posições"] = positionsDashbord,
            ["grid"] = positionsDashbord,
            ["posição na volta"] = positionsDashbord,
            ["posição lap"] = positionsDashbord,
            ["mostra posição"] = positionsDashbord,
            ["abre posição"] = positionsDashbord,

            ["dados de corrida"] = raceData,
            ["ultrapassagens"] = raceData,
            ["dados"] = raceData,
            ["punições"] = raceData,

            ["tempo de volta"] = lapTime,
            ["setor um"] = lapTime,
            ["setor dois"] = lapTime,
            ["setor tres"] = lapTime,
            ["tempo"] = lapTime,

            ["botões"] = controlData,
            ["controle"] = controlData,
            ["dados do controle"] = controlData,

            ["danos na asa"] = wingDamage,
            ["asa frontal"] = wingDamage,
            ["asa traseira"] = wingDamage,
            ["asa esquerda"] = wingDamage,
            ["asa direita"] = wingDamage,

            ["pneu"] = tireData,
            ["dados pneu"] = tireData,

            ["combustivel"] = tireData,
            ["gasolina"] = tireData,
            ["combustivel restante"] = tireData,

            ["fechar"] = closeBrowser,
            ["fecha"] = closeBrowser,
            ["fechar chrome"] = closeBrowser,
            ["fecha tudo"] = closeBrowser,
            ["limpar telas"] = closeBrowser,
            ["fechar dashboards"] = closeBrowser,
            ["sair"] = closeBrowser,

            ["alterar monitor"] = switchMonitor,
            ["mudar monitor"] = switchMonitor,
            ["trocar monitor"] = switchMonitor,
            ["monitor"] = switchMonitor,

            ["limpar"] = cleanCommand,
            ["clear"] = cleanCommand,
            ["limpa"] = cleanCommand,
            ["limpa cmd"] = cleanCommand,

            ["iniciar coleta"] = startTelemetry,
            ["iniciar telemetria"] = startTelemetry,
            ["iniciar"] = startTelemetry,

            ["parar coleta"] = stopTelemetry,
            ["parar telemetria"] = stopTelemetry,
        };

    }
}
