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
        public bool OpenOutputFolder { get; set; }

        /*
         * MODID du mod basé sur le nom du dossier sélectionné par l'utilisateur
         */
        public string Modid { get; private set; }

        public PathManager pathManager { get; private set; }

        /*---------------------------------------------------------*/
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
            Modid = pathPieces[pathPieces.Length - 1].ToLower().Replace(' ', '_');

            Console.WriteLine(pathManager.Assets);
            Console.WriteLine(pathManager.Blockstates);
            Console.WriteLine(pathManager.Blocks);
            Console.WriteLine(pathManager.Items);

            Directory.CreateDirectory(pathManager.Blockstates);
            Directory.CreateDirectory(pathManager.Blocks);
            Directory.CreateDirectory(pathManager.Items);
        }

        /*
         * Méthode appelée lorsque l'utilisateur rajoute un model à générer
         */
        public void OnModelAdd(TextBox textBox, string modelName, GenerationModes model)
        {
            textBox.Text += String.Format("[{0}] : \"{1}\"\n", model.ToString(), modelName);
            textBox.Height = 20 + 20 * (ModelsToGenerate.Keys.Count - 1);
        }

        public void ResetModels(TextBox textBox)
        {
            textBox.Text = "";
            textBox.Height = 20;
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
                            isValid = GenerateBlockStairs(key.Key);
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
                ModelsToGenerate.Clear();
                MessageBox.Show("Tous les modèles ont été générés avec succès dans " + pathManager.Assets);
                return true;
            }
            else
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
            string content = FormatModel(Properties.Resources.generated, name);
            try
            {
                writeItemFile(content, name);
            }
            catch (IOException exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }
            return true;
        }

        /*
         * Model d'outil (stick, épée, pioche, etc...)
         */
        public bool GenerateItemHandheld(string name)
        {
            string content = FormatModel(Properties.Resources.handheld, name);
            try
            {
                writeItemFile(content, name);
            }
            catch (IOException exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }
            return true;
        }

        public bool GenerateBlockCubeAll(string name)
        {
            
            string itemBlockModel = FormatModel(Properties.Resources.itemblock, name);
            string blockModel = FormatModel(Properties.Resources.cube_all_model, name);
            string blockstateModel = FormatModel(Properties.Resources.cube_all_blockstate, name);

            try
            {
                writeItemFile(itemBlockModel, name);
                writeBlockFile(blockModel, name);
                writeBlockstateFile(blockstateModel, name);
                
            }
            catch (IOException exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }


            return true;
        }
        public bool GenerateBlockLog(string name)
        {
            string itemBlockModel = FormatModel(Properties.Resources.itemblock, name);
            string blockModel = FormatModel(Properties.Resources.cube_log, name);
            string blockModel_horizontal = FormatModel(Properties.Resources.cube_log_horizontal, name);
            string blockstateModel = FormatModel(Properties.Resources.cube_log_blockstate, name);

            try
            {
                writeItemFile(itemBlockModel, name);
                writeBlockFile(blockModel, name);
                writeBlockFile(blockModel_horizontal, name + "_horizontal");
                writeBlockstateFile(blockstateModel, name);

            }
            catch (IOException exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }

            return true;
        }
        public bool GenerateBlockFurnace(string name)
        {
            string itemBlockModel = FormatModel(Properties.Resources.itemblock, name);
            string blockModel = FormatModel(Properties.Resources.cube_furnace, name);
            string blockModel_on = FormatModel(Properties.Resources.cube_furnace_on, name);
            string blockstateModel = FormatModel(Properties.Resources.cube_furnace_blockstate, name);

            try
            {
                writeItemFile(itemBlockModel, name);
                writeBlockFile(blockModel, name);
                writeBlockFile(blockModel_on, name + "_on");
                writeBlockstateFile(blockstateModel, name);

            }
            catch (IOException exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }
            return true;
        }
        public bool GenerateBlockStairs(string name)
        {
            string itemBlockModel = FormatModel(Properties.Resources.itemblock, name);
            string blockModel = FormatModel(Properties.Resources.cube_stairs_model, name);
            string blockModel_inner = FormatModel(Properties.Resources.cube_stairs_inner_model, name);
            string blockModel_outer = FormatModel(Properties.Resources.cube_stairs_outer_model, name);
            string blockstateModel = FormatModel(Properties.Resources.cube_stairs_blockstates, name);

            try
            {
                writeItemFile(itemBlockModel, name);
                writeBlockFile(blockModel, name);
                writeBlockFile(blockModel_inner, name + "_inner");
                writeBlockFile(blockModel_outer, name + "_outer");
                writeBlockstateFile(blockstateModel, name);

            }
            catch (IOException exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }
            return true;
        }

        private string FormatModel(string model, string name)
        {
            return model.Replace("modid", Modid).Replace("name", name);
        }

        private void writeItemFile(string content, string name)
        {
            File.WriteAllText(pathManager.Items + name + ".json", content);
        }

        private void writeBlockFile(string content, string name)
        {
            File.WriteAllText(pathManager.Blocks + name + ".json", content);
        }

        private void writeBlockstateFile(string content, string name)
        {
            File.WriteAllText(pathManager.Blockstates + name + ".json", content);
        }

        /*--------------------------------------------------------------*/
        /*--------------------------------------------------------------*/

    }
}
