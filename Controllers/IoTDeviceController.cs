﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.Azure.Devices;
using System.Threading.Tasks;
using Microsoft.Azure.Devices.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;


namespace IOTDeviceApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IoTDeviceController : ControllerBase
    {
        //private static DeviceClient s_deviceClient;
        [Route("AddDevice")]
        [HttpGet]
        public async Task<Device> AddDeviceAsync(string deviceId)
        {
            dynamic device = await IOTDeviceApp.Models.IoTDevice.AddDeviceAsync(deviceId);
            return device;
        }

        [Route("GetDevice")]
        [HttpGet]
        public async Task<Device> GetDeviceAsync(string deviceId)
        {
            dynamic device = await IOTDeviceApp.Models.IoTDevice.GetDeviceAsync(deviceId);
            return device;
        }

        [Route("UpdateDevice")]
        [HttpPut]
        public IActionResult UpdateDeviceAsync(string deviceId)
        {
            dynamic device = IOTDeviceApp.Models.IoTDevice.UpdateDeviceAsync(deviceId);
            return Ok(device);
        }

        [Route("RemoveDevice")]
        [HttpDelete]
        public IActionResult RemoveDeviceAsync(string deviceId)
        {
            dynamic device = IOTDeviceApp.Models.IoTDevice.RemoveDeviceAsync(deviceId);
            return Ok("Success");
        }

        [Route("sendTelemetryToCloudMessage")]
        [HttpPost]
        public IActionResult SendDeviceToCloudMessageAsync()
        {
            IOTDeviceApp.Models.IoTDeviceTelemetryMessage.SendDeviceToCloudMessagesAsync();
            return Ok("Success");
        }

    }
}


