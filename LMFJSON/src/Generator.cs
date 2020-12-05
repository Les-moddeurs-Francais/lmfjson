using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace LMFJSON.src
{
    class Generator
    {
        /*---------------------VARIABLES---------------------------*/
        /*---------------------------------------------------------*/

        /*
         * DICTIONNAIRE remplit par les unlocalized name des items/blocks (key) avec leur type de models (value)
         */
        public Dictionary<string, GenerationModes> ModelsToGenerate { get; private set; }
        
        /*
         * Chemin vers le dossier principal du mod
         */
        public string OutputFolderPath { get; set; }
        
        /*
         * BOOL permettant à l'utilisateur d'ouvrir le dossier assets à la fin de la génération des models
         */
        public bool OpenOutputFolder { get; set;}
        
        /*
         * MODID du mod basé sur le nom du dossier sélectionné par l'utilisateur
         */
        public string Modid { get; private set; }

        public PathManager pathManager { get; private set; }

        /*---------------------------------------------------------*/

        public Generator()
        {
            ModelsToGenerate = new Dictionary<string, GenerationModes>();
            pathManager = new PathManager(this);
        }


        /*--------------------------------------------------------------*/
        /*------------------------METHODS-------------------------------*/


        /*
         * Méthode appelée lorsqu'on change le dossier du mod principal pour effectuer les changements de modid, etc...
         */
        public void OnOutputPathChanged()
        {
            /*
             * UPDATE du modid lorsqu'on change de dossier de mod
             */

            string[] pathPieces = OutputFolderPath.Split('\\');
            Modid = pathPieces[pathPieces.Length - 1];

            Console.WriteLine(pathManager.Assets);
            Console.WriteLine(pathManager.Blockstates);
            Console.WriteLine(pathManager.Blocks);
            Console.WriteLine(pathManager.Items);
        }

        /*
         * Méthode appelée lorsque l'utilisateur rajoute un model à générer
         */
        public void OnModelAdd(TextBox textBox, string modelName, GenerationModes model)
        {
            textBox.Text += String.Format("[{0}] : \"{1}\"\n", model.ToString(), modelName);
            textBox.Height = 20 + 20 * (ModelsToGenerate.Keys.Count-1);
        }

        /*
         * Méthode générale où tous les modèles se génèrent
         */
        public bool GenerateAll()
        {
            if (OutputFolderPath != "" && Modid != "" && ModelsToGenerate.Count > 0)
            {
                foreach (var key in ModelsToGenerate)
                {
                    bool isValid = false;
                    switch (key.Value)
                    {
                        case GenerationModes.GENERATED:
                            isValid = GenerateItemGenerated(key.Key);
                            break;

                        case GenerationModes.HANDHELD:
                            isValid = GenerateItemHandheld(key.Key);
                            break;

                        case GenerationModes.CUBE_ALL:
                            isValid = GenerateBlockCubeAll(key.Key);
                            break;

                        case GenerationModes.LOG:
                            isValid = GenerateBlockLog(key.Key);
                            break;

                        case GenerationModes.FURNACE:
                            isValid = GenerateBlockFurnace(key.Key);
                            break;

                        case GenerationModes.STAIRS:
                            break;

                        case GenerationModes.SLABS:
                            break;

                        case GenerationModes.DOORS:
                            break;

                        case GenerationModes.FENCES:
                            break;

                        case GenerationModes.FENCE_GATE:
                            break;

                        case GenerationModes.CROPS:
                            break;

                        case GenerationModes.FLOWER:
                            break;

                        case GenerationModes.BUTTON:
                            break;

                    }
                    // Si jamais une génération se passe mal
                    if (!isValid)
                    {
                        MessageBox.Show("Une erreur s'est produite lors de la génération du model \"" + key.Key + "\"");
                        return false;
                    }
                }
                return true;
            }else
            {
                MessageBox.Show("You must set the path of your mod folder and/or add at least 1 model to generate !");
                return false;
            }
        }

        /*
         * Model d'item basique (pomme, lingot, etc...)
         */
        public bool GenerateItemGenerated(string name)
        {
            return true;
        }

        /*
         * Model d'outil (stick, épée, pioche, etc...)
         */
        public bool GenerateItemHandheld(string name)
        {
            return true;
        }

        public bool GenerateBlockCubeAll(string name)
        {
            return true;
        }
        public bool GenerateBlockLog(string name)
        {
            return true;
        }
        public bool GenerateBlockFurnace(string name)
        {
            return true;
        }
        public bool GenerateBlockStairs(string name)
        {
            return true;
            
        }
     
        /*--------------------------------------------------------------*/

    }
}
