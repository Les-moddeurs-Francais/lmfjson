﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LMFJSON.Properties {
    using System;
    
    
    /// <summary>
    ///   Une classe de ressource fortement typée destinée, entre autres, à la consultation des chaînes localisées.
    /// </summary>
    // Cette classe a été générée automatiquement par la classe StronglyTypedResourceBuilder
    // à l'aide d'un outil, tel que ResGen ou Visual Studio.
    // Pour ajouter ou supprimer un membre, modifiez votre fichier .ResX, puis réexécutez ResGen
    // avec l'option /str ou régénérez votre projet VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Retourne l'instance ResourceManager mise en cache utilisée par cette classe.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("LMFJSON.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Remplace la propriété CurrentUICulture du thread actuel pour toutes
        ///   les recherches de ressources à l'aide de cette classe de ressource fortement typée.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Recherche une ressource localisée de type System.IO.UnmanagedMemoryStream semblable à System.IO.MemoryStream.
        /// </summary>
        public static System.IO.UnmanagedMemoryStream click_sound {
            get {
                return ResourceManager.GetStream("click_sound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à {
        ///  &quot;variants&quot;: {
        ///    &quot;&quot;: {
        ///      &quot;model&quot;: &quot;modid:block/name&quot;
        ///    }
        ///  }
        ///}.
        /// </summary>
        public static string cube_all_blockstate {
            get {
                return ResourceManager.GetString("cube_all_blockstate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à {
        ///  &quot;parent&quot;: &quot;minecraft:block/cube_all&quot;,
        ///  &quot;textures&quot;: {
        ///    &quot;all&quot;: &quot;modid:block/name&quot;
        ///  }
        ///}.
        /// </summary>
        public static string cube_all_model {
            get {
                return ResourceManager.GetString("cube_all_model", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à {
        ///  &quot;parent&quot;: &quot;item/generated&quot;,
        ///  &quot;textures&quot;: {
        ///    &quot;layer0&quot;: &quot;modid:item/name&quot;
        ///  }
        ///}.
        /// </summary>
        public static string generated {
            get {
                return ResourceManager.GetString("generated", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à {
        ///  &quot;parent&quot;: &quot;minecraft:item/handheld&quot;,
        ///  &quot;textures&quot;: {
        ///    &quot;layer0&quot;: &quot;modid:item/name&quot;
        ///  }
        ///}.
        /// </summary>
        public static string handheld {
            get {
                return ResourceManager.GetString("handheld", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à {
        ///  &quot;parent&quot;: &quot;modid:block/name&quot;
        ///}.
        /// </summary>
        public static string itemblock {
            get {
                return ResourceManager.GetString("itemblock", resourceCulture);
            }
        }
    }
}
