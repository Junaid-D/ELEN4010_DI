using System;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models;
using System.Collections.Generic;
using Microsoft.Rest;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace DB_man.Classification
{

    class ApiKeyServiceClientCredentials : ServiceClientCredentials
    {
        private const string SubscriptionKey = "1d0968b7e974483a973ec6406209d0df";
        public override Task ProcessHttpRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Add("Ocp-Apim-Subscription-Key", SubscriptionKey);
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
                Endpoint = "https://centralus.api.cognitive.microsoft.com"
            }; //Replace 'westus' with the correct region for your Text Analytics subscription



            var inputList = new List<MultiLanguageInput>();

            int i = 1;
            foreach(string s in inputData)
            {
                inputList.Add(new MultiLanguageInput("en",i.ToString(), s));
                i++;

            }
            try
            {
                KeyPhraseBatchResult result = client.KeyPhrasesAsync
                    (false, new MultiLanguageBatchInput(inputList)).Result;

                foreach (var document in result.Documents)
                {
                    foreach (string keyphrase in document.KeyPhrases)
                    {
                        res.Add(keyphrase);
                    }
                }
            }
            catch(Exception e)
            {

            }

            return res;
        }
    }
}
