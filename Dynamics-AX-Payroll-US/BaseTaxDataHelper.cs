// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

using System.IO;

namespace Microsoft.Dynamics.AX.Application.HumanCapitalManagement.Payroll
{
    public class BaseTaxDataHelper
    {
        const string baseTaxDataXmlFilePath = @"STE\PayrollBaseTaxData.xml";

        /// <summary>
        /// Provides access to the payroll base tax data xml data associated with the currently-installed
        /// payroll tax engine.
        /// </summary>
        /// <returns>A <c>StreamReader</c> instance for the PayrollBaseTaxData.xml file associated with the payroll
        /// tax engine.</returns>
        public static StreamReader GetBaseTaxDataXml()
        {
            // The path to the bases tax data xml file stored in the tax engine folder relative to this assembly
            string path = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), baseTaxDataXmlFilePath);

            return new StreamReader(path);
        }
    }
}
