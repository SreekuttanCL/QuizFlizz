//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: global::Xamarin.Forms.Xaml.XamlResourceIdAttribute("QuizApp.Pages.PoliticsPage.xaml", "Pages/PoliticsPage.xaml", typeof(global::QuizApp.PoliticsPage))]

namespace QuizApp {
    
    
    [global::Xamarin.Forms.Xaml.XamlFilePathAttribute("Pages/PoliticsPage.xaml")]
    public partial class PoliticsPage : global::QuizApp.Base {
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Xamarin.Forms.Label questionLabel;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Xamarin.Forms.ProgressBar PoliticsBar;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private void InitializeComponent() {
            global::Xamarin.Forms.Xaml.Extensions.LoadFromXaml(this, typeof(PoliticsPage));
            questionLabel = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.Label>(this, "questionLabel");
            PoliticsBar = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.ProgressBar>(this, "PoliticsBar");
        }
    }
}
