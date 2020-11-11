using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PickupService.Services
{
    public class PickupEstimatorService : PickupEstimator.PickupEstimatorBase
    {
        public override Task<PickupResponse> GetPickupTime(PickupRequest request, ServerCallContext context)
        {
            //for orders under 5 items, tomorrow, over five items, two days.
            int days = 0;
            if (request.Items.Count <= 5)
            {
                days = 1;
            }
            else
            {
                days = 2;
            }
            var response = new PickupResponse
            {
                PickupTime = Timestamp.FromDateTime(DateTime.Now.AddDays(days).ToUniversalTime())
            };
            return Task.FromResult(response);
        }
    }
}
