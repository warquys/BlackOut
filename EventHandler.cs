using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using MEC;
using System.Collections.Generic;

namespace BlackOut
{
    public class EventHandler
    {

        #region Properties & Variables
        private readonly Config _config;

        public List<ZoneType> BlackoutAffectedZone { get; private set; }

        private CoroutineHandle BlackoutCoroutineHandler;
        public bool BlackoutCoroutineRuning 
        {
            get => BlackoutCoroutineHandler.IsRunning;
            set
            {
                if (BlackoutCoroutineRuning == value) return;

                if (value)
                    BlackoutCoroutineHandler = Timing.RunCoroutine(BlackoutCoroutine());
                else
                    Timing.KillCoroutines(BlackoutCoroutineHandler);
            }
        }

        #endregion

        #region Constructor & Destructor
        internal EventHandler(Config config)
        {
            _config = config;
            BlackoutAffectedZone = new List<ZoneType>() { ZoneType.Entrance, ZoneType.HeavyContainment, ZoneType.LightContainment };
            AttachEvent();
        }
        #endregion

        #region Methods
        public void AttachEvent()
        {
            Exiled.Events.Handlers.Server.RoundStarted += OnRoundStart;
            Exiled.Events.Handlers.Server.RoundEnded += OnRoundEnd;
        }

        public void DetachEvent()
        {
            Exiled.Events.Handlers.Server.RoundStarted -= OnRoundStart;
            Exiled.Events.Handlers.Server.RoundEnded -= OnRoundEnd;
        }

        private IEnumerator<float> BlackoutCoroutine()
        {
            yield return Timing.WaitForSeconds(UnityEngine.Random.Range(_config.Min_Blackout_Start_Time, _config.Max_Blackout_Start_Time));

        rep:
            var time = TimeForNextBlackOut();
            
            foreach (var zone in BlackoutAffectedZone)
                Map.TurnOffAllLights(time, zone);
            
            if (_config.Cassie_On)
            {
                Cassie.Message(_config.Cassie_OffLight, false, true, _config.Subtitles);
                yield return Timing.WaitForSeconds(time);
                Cassie.Message(_config.Cassie_OnLight, false, true, _config.Subtitles);

            }
            else yield return Timing.WaitForSeconds(time);

            yield return TimeForNextBlackOut();

            goto rep; //Yea old school

            float TimeForNextBlackOut()
            {
                var randomTime = UnityEngine.Random.Range(_config.Min_Blackout_Start_Time, _config.Max_Blackout_Start_Time);
                return Timing.WaitForSeconds(randomTime);
            }
        }
        #endregion

        #region Events
        private void OnRoundStart()
        {
            BlackoutCoroutineRuning = true;
        }

        private void OnRoundEnd(RoundEndedEventArgs ev)
        {
            BlackoutCoroutineRuning = false;
        }
        #endregion
    }
}
