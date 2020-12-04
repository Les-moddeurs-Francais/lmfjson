using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMFJSON.src
{
    internal class PathManager
    {

        private src.Generator gen { get; }

        public string Assets { get { return gen.OutputFolderPath + "\\src\\main\\resources\\assets\\" + gen.Modid + "\\"; } }
        public string Blockstates { get { return Assets + "blockstates\\"; } }
        public string Blocks { get { return Assets + "models\\block\\"; } }
        public string Items { get { return Assets + "models\\item\\"; } }


        public PathManager(src.Generator generator)
        {
            gen = generator;
        }
    }
}
