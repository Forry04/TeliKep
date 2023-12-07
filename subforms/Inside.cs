using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeliKep.subforms
{
    public partial class Inside : Form
    {
        public SoundPlayer player = new SoundPlayer(@"../../../src/fire.wav");
        public Inside(Size _size)
        {
            InitializeComponent();
            player.Play();
            this.Size =  _size;
        }
        
    }
}
