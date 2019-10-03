using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ServiceBlock.Interface.Resource;
using WeatherForecast.Interface;

namespace WeatherForecast
{
    public class ForecastTransformer : ResourceTransformer<WeatherForecasts>
    {
        public override Task<WeatherForecasts> OnCreate(WeatherForecasts resource)
        {
            resource.Id = Guid.NewGuid();
            return Task.FromResult(resource);
        }


        public override Task<WeatherForecasts> OnRead(WeatherForecasts resource)
        {
            resource.Summary = "Ha hahaha hahaha";
            return Task.FromResult(resource);
        }

    }
}