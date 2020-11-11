using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PickupService.Services
{
    public class TurnByTurnService : TurnByTurn.TurnByTurnBase
    {
        public override async Task StartGuidance(Destination request, IServerStreamWriter<Step> responseStream, ServerCallContext context)
        {
            var steps = new List<Step>
            {
                new Step() {Direction="Left", Road="Prospect"},
                new Step() {Direction="Left", Road="Darrow"},
                new Step() {Direction="Right", Road="Herrick"},
                new Step() {Direction="Left", Road="Prospect"},
                new Step() {Direction="Left", Road="Darrow"},
                new Step() {Direction="Right", Road="Herrick"},
                new Step() {Direction="Left", Road="Prospect"},
                new Step() {Direction="Left", Road="Darrow"},
                new Step() {Direction="Right", Road="Herrick"}
            };

            foreach(var step in steps)
            {
                await Task.Delay(new Random().Next(1500, 3000));
                await responseStream.WriteAsync(step);
            }
        }
    }
}
