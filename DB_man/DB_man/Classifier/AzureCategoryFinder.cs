using System;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models;
using System.Collections.Generic;
using Microsoft.Rest;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

//
//as per the Microsoft tutorial
//https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/quickstarts/csharp
//

namespace DB_man.Classification
{
    /// <summary>
    /// This is used for keyword analysis using the Azure text analytics API. This API is integrated via a NuGet package instead of using the RESTful API directly.
    /// </summary>

    class ApiKeyServiceClientCredentials : ServiceClientCredentials
    {
        private string subscriptionKey = "";
        public override Task ProcessHttpRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            subscriptionKey= System.Configuration.ConfigurationManager.AppSettings["AnalyticsKey"].ToString();//fetch key from config

            request.Headers.Add("Ocp-Apim-Subscription-Key", subscriptionKey);
            return base.ProcessHttpRequestAsync(request, cancellationToken);
        }
    }


    class AzureCategoryFinder : ICategoryFinder
    {

        public List<string> getCategories(List<string> inputData)
        {
            List<string> res = new List<string>();
            ITextAnalyticsClient client = new TextAnalyticsClient(new ApiKeyServiceClientCredentials())
            {
                Endpoint = "https://centralus.api.cognitive.microsoft.com"//azure services were registerd to centralus server.
            }; 

            var inputList = new List<MultiLanguageInput>();
            //multilanguage input structure is needed despite all articles being in english, despite the out of date tutorial

            int i = 1;
            //build argument list for keyword analysis
            foreach (string s in inputData)
            {
                inputList.Add(new MultiLanguageInput("en", i.ToString(), s));
                i++;//each input needs an id
            }
            try
            {
                //ignore stats
                KeyPhraseBatchResult result = client.KeyPhrasesAsync
                    (false, new MultiLanguageBatchInput(inputList)).Result;
                //response from API
                foreach (var document in result.Documents)
                {
                    foreach (string keyphrase in document.KeyPhrases)
                    {
                        res.Add(keyphrase);
                    }
                }
            }
            catch (Exception e)
            {

            }

            return res;
        }
    }
}
