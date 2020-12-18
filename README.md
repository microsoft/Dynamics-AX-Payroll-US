
# Contributing

This project welcomes contributions and suggestions.  Most contributions require you to agree to a
Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us
the rights to use your contribution. For details, visit https://cla.opensource.microsoft.com.

When you submit a pull request, a CLA bot will automatically determine whether you need to provide
a CLA and decorate the PR appropriately (e.g., status check, comment). Simply follow the instructions
provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).
For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or
contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.


# Build Remarks

This project requires the Symmetry tax engine dll to run. Modify the hint path of the ste-net in the project to reference the location of the Symmetry tax engine. Hints to modify the location path of the Symmetry tax engine dll
1. Open the .csproj file in a editor of your preference
2. Look for the ItemGroup property that contains the references to the project and modify the HintPath property of ste-net to the location where the ste-net dll is placed
3. Save and build the project