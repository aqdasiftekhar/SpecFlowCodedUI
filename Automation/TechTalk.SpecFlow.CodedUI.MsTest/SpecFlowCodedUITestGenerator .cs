using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.Generator.UnitTestProvider;
using TechTalk.SpecFlow.Utils;

namespace TechTalk.SpecFlow.CodedUI.MsTest
{
    public class SpecFlowCodedUITestGenerator : MsTestGeneratorProvider
    {
        public SpecFlowCodedUITestGenerator(CodeDomHelper codeDomHelper)
            : base(codeDomHelper)
        {
        }

        public override void SetTestClass(TechTalk.SpecFlow.Generator.TestClassGenerationContext generationContext, string featureTitle, string featureDescription)
        {
            base.SetTestClass(generationContext, featureTitle, featureDescription);

            foreach (CodeAttributeDeclaration customAttribute in generationContext.TestClass.CustomAttributes)
            {
                if (customAttribute.Name == "Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute")
                {
                    generationContext.TestClass.CustomAttributes.Remove(customAttribute);
                    break;
                }
            }

            generationContext.TestClass.CustomAttributes.Add(new CodeAttributeDeclaration(new CodeTypeReference("Microsoft.VisualStudio.TestTools.UITesting.CodedUITestAttribute")));
        }
    }
}
