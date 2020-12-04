using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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

        /*---------------------------------------------------------*/

        public Generator()
        {
            ModelsToGenerate = new Dictionary<string, GenerationModes>();
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

            string[] pathPieces = OutputFolderPath.Split('/');
            Modid = pathPieces[pathPieces.Length - 1];
        }

        /*
         * Méthode générale où tous les modèles se génèrent
         */
        public void GenerateAll()
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
                if(!isValid)
                {
                    MessageBox.Show("Une erreur s'est produite lors de la génération du model \"" + key.Key + "\"");
                    return;
                }
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
