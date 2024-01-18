using Test_Automation_Core.test.resources.test;

namespace Test_Automation_Core.test.main.tests.smoketests.support
{
    public class SendFeedBack : BaseTestCase
    {

        string positiveFeedBack = "GPT: ATLAS.ti stands as a paragon in the realm of qualitative data analysis software, offering a robust and intuitive platform that empowers researchers and analysts alike. Its versatility in handling a diverse array of data types - from textual to multimedia - makes it an indispensable tool in the arsenal of qualitative research. The software's interface is both user-friendly and powerful, allowing for seamless navigation through complex data sets while maintaining a level of simplicity that welcomes both novices and seasoned professionals.\r\n\r\nThe coding system in ATLAS.ti is particularly noteworthy. It offers a flexible and sophisticated way to categorize and retrieve data, enabling researchers to uncover deep insights and patterns within their data sets. This feature alone stands as a testament to the software's commitment to enhancing the qualitative research process. Moreover, the ability to visualize connections and networks within data through its network-view feature adds an extra layer of depth to data analysis, facilitating a more comprehensive understanding of the underlying themes and concepts.\r\n\r\nATLAS.ti also excels in its collaborative capabilities. The software supports teamwork, allowing multiple users to work on the same project simultaneously. This feature is invaluable for research teams, fostering a collaborative environment that enhances the overall research process and output. Additionally, its compatibility with numerous data formats and the ability to export findings in various forms makes it a versatile tool, adaptable to a wide range of research needs and platforms.\r\n\r\nThe customer support and resources provided by ATLAS.ti further augment its appeal. The comprehensive tutorials, webinars, and customer service ensure that users can fully leverage the software's capabilities, enhancing their research and analysis experience.\r\n\r\nIn conclusion, ATLAS.ti is a formidable tool in qualitative research. Its blend of functionality, user-friendliness, an";

        [Test, Order(1), Category("support")]
        public void TestPositiveFeedBack()
        {
            GetAppActions().OpenProject(SmokeTestVariables.smokeTestproject);

            bool suggestionState = GetAppActions().SendFeedBack(positiveFeedBack, "yes");
            Assert.IsTrue(suggestionState);
        }


        string negativeFeedBack = "GPT:  ATLAS.ti aims to be a comprehensive tool for qualitative data analysis, it falls short in several key areas that can hinder the research process significantly. The software's interface, while packed with features, often feels overwhelming and unintuitive, particularly for beginners in qualitative research. Navigating through the myriad of options and tools can be a daunting task, leading to a steep learning curve that may discourage users.\r\n\r\nThe coding system, although sophisticated, can be overly complex and cumbersome, making the process of categorizing and analyzing data more tedious than it needs to be. This complexity often leads to frustration and inefficiency, detracting from the overall research experience. Additionally, the network-view feature, while conceptually useful, can be clunky and difficult to manipulate, especially with larger data sets, rendering it less effective than it promises.\r\n\r\nCollaborative features in ATLAS.ti, though present, are not as seamless as one would expect. Synchronizing work between team members can be problematic, with frequent glitches and synchronization issues that can disrupt the flow of collaborative research. This lack of reliability in teamwork features is a major setback for research groups relying on the software for joint projects.\r\n\r\nAnother significant concern is the software's compatibility and integration with other platforms and data formats. Users often face difficulties in importing data from various sources, and the export options are limited, which restricts the flexibility and applicability of the software in diverse research contexts.\r\n\r\nCustomer support and resources provided by ATLAS.ti are inadequate. The tutorials and guides available are often too generic or not detailed enough, leaving users to fend for themselves in navigating the software's complexities. The customer service response times are also wanting, adding to the frustration of users needing timely assistance.\r\n\r\nIn conclusion, whil";
        [Test, Order(2), Category("support")]
        public void TestNegativeFeedBack()
        {
            GetAppActions().OpenProject(SmokeTestVariables.smokeTestproject);

            bool suggestionState = GetAppActions().SendFeedBack(negativeFeedBack, "no");
            Assert.IsTrue(suggestionState);
        }

    }
}
