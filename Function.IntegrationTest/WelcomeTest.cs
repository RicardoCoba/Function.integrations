using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Net.Http;
using System.Threading.Tasks;

namespace Function.IntegrationsTest
{
   [Collection(nameof(TestCollection))]
    public class WelcomeTest
    {
        private TestFixture testFixture;
        private HttpResponseMessage httpResponseMessage;
       public WelcomeTest(TestFixture fixture)
        {
            testFixture = fixture;
        }
       
        [Fact]
        public async Task WhenfunctionIsInvoked()
        {
            httpResponseMessage = await testFixture.Client.GetAsync("api/Welcome/?name=Ricardo");
            Assert.True(httpResponseMessage.IsSuccessStatusCode);
        }
        [Fact]
        public async Task WhenResponseWnWith()
        {
            httpResponseMessage = await testFixture.Client.GetAsync("api/Welcome/?name=Ricardo");
            Assert.EndsWith("Success.", await httpResponseMessage.Content.ReadAsStringAsync());
        }
    }
}
