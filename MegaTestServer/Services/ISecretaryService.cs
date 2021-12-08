using DocsVision.Platform.WebClient;
using MegaTestServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MegaTestServer.Services
{
    public interface ISecretaryService
    {
        SecretaryData GetSecretary(SessionContext context, string nameGroup);
    }
}