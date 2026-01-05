using F1VoiceDashboardWorker.Settings;
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
        public readonly DashboardsF1 DashboardsF1Data;
        public Dictionary<string, string> CommandsUrl;
        static readonly string closeBrowser = "FECHAR_NAVEGADOR";
        static readonly string cleanCommand = "LIMPAR";
        static readonly string switchMonitor = "ALTERAR_MONITOR";
        static readonly string startTelemetry = "INICIAR_TELEMETRIA";
        static readonly string stopTelemetry = "PARAR_TELEMETRIA";
        public Commands(DashboardsF1 dashboardData)
        {
            DashboardsF1Data = dashboardData;

            CommandsUrl = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                #region Portuguese Commands
                ["posição"] = DashboardsF1Data.Positions,
                ["posições"] = DashboardsF1Data.Positions,
                ["grid"] = DashboardsF1Data.Positions,
                ["posição na volta"] = DashboardsF1Data.Positions,
                ["posição lap"] = DashboardsF1Data.Positions,
                ["mostra posição"] = DashboardsF1Data.Positions,
                ["abre posição"] = DashboardsF1Data.Positions,

                ["dados de corrida"] = DashboardsF1Data.RaceData,
                ["ultrapassagens"] = DashboardsF1Data.RaceData,
                ["dados"] = DashboardsF1Data.RaceData,
                ["punições"] = DashboardsF1Data.RaceData,

                ["tempo de volta"] = DashboardsF1Data.LapTime,
                ["setor um"] = DashboardsF1Data.LapTime,
                ["setor dois"] = DashboardsF1Data.LapTime,
                ["setor tres"] = DashboardsF1Data.LapTime,
                ["tempo"] = DashboardsF1Data.LapTime,

                ["botões"] = DashboardsF1Data.ControlData,
                ["controle"] = DashboardsF1Data.ControlData,
                ["dados do controle"] = DashboardsF1Data.ControlData,

                ["danos na asa"] = DashboardsF1Data.WingDamage,
                ["asa frontal"] = DashboardsF1Data.WingDamage,
                ["asa traseira"] = DashboardsF1Data.WingDamage,
                ["asa esquerda"] = DashboardsF1Data.WingDamage,
                ["asa direita"] = DashboardsF1Data.WingDamage,

                ["pneu"] = DashboardsF1Data.TireData,
                ["dados pneu"] = DashboardsF1Data.TireData,

                ["combustivel"] = DashboardsF1Data.FuelData,
                ["gasolina"] = DashboardsF1Data.FuelData,
                ["combustivel restante"] = DashboardsF1Data.FuelData,
                ["combustível"] = DashboardsF1Data.FuelData,
                ["combustível restante"] = DashboardsF1Data.FuelData,

                ["carro setup"] = DashboardsF1Data.CarSetup,
                ["dados carro"] = DashboardsF1Data.CarSetup,
                ["configuração carro"] = DashboardsF1Data.CarSetup,
                ["configuração"] = DashboardsF1Data.CarSetup,
                ["ajustes do carro"] = DashboardsF1Data.CarSetup,

                ["bateria"] = DashboardsF1Data.Battery,
                ["ers"] = DashboardsF1Data.Battery,
                ["uso de bateria"] = DashboardsF1Data.Battery,
                ["média de uso de bateria"] = DashboardsF1Data.Battery,

                ["modo de ultrapassagem"] = DashboardsF1Data.DRS,
                ["ativar drs"] = DashboardsF1Data.DRS,
                ["ativar drs"] = DashboardsF1Data.DRS,
                ["abrir asa"] = DashboardsF1Data.DRS,

                ["Tempo de parada"] = DashboardsF1Data.PitStopTime,
                ["Pit Stop"] = DashboardsF1Data.PitStopTime,
                ["Tempo nos boxes"] = DashboardsF1Data.PitStopTime,

                ["dano no carro"] = DashboardsF1Data.CarDamage,
                ["dano carro"] = DashboardsF1Data.CarDamage,
                ["dano no sidepod"] = DashboardsF1Data.CarDamage,
                ["sidepod"] = DashboardsF1Data.CarDamage,
                ["dano na caixa de cambio"] = DashboardsF1Data.CarDamage,
                ["status dano no carro"] = DashboardsF1Data.CarDamage,
                ["informações dano no carro"] = DashboardsF1Data.CarDamage,

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
                #endregion
                #region English Commands
                ["position"] = DashboardsF1Data.Positions,
                ["positions"] = DashboardsF1Data.Positions,
                ["standings"] = DashboardsF1Data.Positions,
                ["grid position"] = DashboardsF1Data.Positions,
                ["show position"] = DashboardsF1Data.Positions,
                ["open position"] = DashboardsF1Data.Positions,

                ["race data"] = DashboardsF1Data.RaceData,
                ["overtakes"] = DashboardsF1Data.RaceData,
                ["overtaking"] = DashboardsF1Data.RaceData,
                ["penalties"] = DashboardsF1Data.RaceData,
                ["punishments"] = DashboardsF1Data.RaceData,

                ["lap time"] = DashboardsF1Data.LapTime,
                ["sector one"] = DashboardsF1Data.LapTime,
                ["sector two"] = DashboardsF1Data.LapTime,
                ["sector three"] = DashboardsF1Data.LapTime,
                ["sector 1"] = DashboardsF1Data.LapTime,
                ["sector 2"] = DashboardsF1Data.LapTime,
                ["sector 3"] = DashboardsF1Data.LapTime,
                ["time"] = DashboardsF1Data.LapTime,

                ["buttons"] = DashboardsF1Data.ControlData,
                ["control"] = DashboardsF1Data.ControlData,
                ["control data"] = DashboardsF1Data.ControlData,

                ["wing damage"] = DashboardsF1Data.WingDamage,
                ["front wing"] = DashboardsF1Data.WingDamage,
                ["rear wing"] = DashboardsF1Data.WingDamage,
                ["left wing"] = DashboardsF1Data.WingDamage,
                ["right wing"] = DashboardsF1Data.WingDamage,

                ["tire"] = DashboardsF1Data.TireData,
                ["tyre"] = DashboardsF1Data.TireData,          
                ["tire data"] = DashboardsF1Data.TireData,
                ["tyre data"] = DashboardsF1Data.TireData,

                ["fuel"] = DashboardsF1Data.FuelData,
                ["remaining fuel"] = DashboardsF1Data.FuelData,
                ["fuel remaining"] = DashboardsF1Data.FuelData,

                ["car setup"] = DashboardsF1Data.CarSetup,
                ["car settings"] = DashboardsF1Data.CarSetup,
                ["setup"] = DashboardsF1Data.CarSetup,
                ["car configuration"] = DashboardsF1Data.CarSetup,

                ["battery"] = DashboardsF1Data.Battery,
                ["ers status"] = DashboardsF1Data.Battery,
                ["battery usage"] = DashboardsF1Data.Battery,
                ["average battery usage"] = DashboardsF1Data.Battery,

                ["drs"] = DashboardsF1Data.DRS,
                ["open drs"] = DashboardsF1Data.DRS,
                ["activate drs"] = DashboardsF1Data.DRS,
                ["overtake mode"] = DashboardsF1Data.DRS,

                ["pit stop time"] = DashboardsF1Data.PitStopTime,
                ["pit time"] = DashboardsF1Data.PitStopTime,
                ["box time"] = DashboardsF1Data.PitStopTime,

                ["car damage"] = DashboardsF1Data.CarDamage,
                ["sidepod damage"] = DashboardsF1Data.CarDamage,
                ["side pod"] = DashboardsF1Data.CarDamage,
                ["engine damage"] = DashboardsF1Data.CarDamage,
                ["gearbox damage"] = DashboardsF1Data.CarDamage,
                ["gearbox"] = DashboardsF1Data.CarDamage,

                ["close"] = closeBrowser,
                ["exit"] = closeBrowser,
                ["quit"] = closeBrowser,
                ["close browser"] = closeBrowser,
                ["close all"] = closeBrowser,
                ["close dashboards"] = closeBrowser,

                ["switch monitor"] = switchMonitor,
                ["change monitor"] = switchMonitor,

                ["clean"] = cleanCommand,
                ["clear screen"] = cleanCommand,

                ["start telemetry"] = startTelemetry,
                ["start collection"] = startTelemetry,
                ["begin telemetry"] = startTelemetry,

                ["stop telemetry"] = stopTelemetry,
                ["stop collection"] = stopTelemetry,
                ["end telemetry"] = stopTelemetry,
                #endregion
            };
        }
    }
}
