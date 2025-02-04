using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_PERSONA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.DATOS();
        }


        public void DATOS()
        {
            using (CRUD_PERSONA_BDEntities db = new CRUD_PERSONA_BDEntities())
            {
                dgvPersona.DataSource = db.Persona.ToList();
            }

        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            using(CRUD_PERSONA_BDEntities db = new CRUD_PERSONA_BDEntities())
            {
                Persona data = new Persona();

                if (txtNombre.Text.Length <= 0 || txtEdad.Text.Length <= 0)
                {
                    MessageBox.Show("Digite datos validos para insertar la persona");
                    return;
                }
                else
                {
                    data.Nombre = txtNombre.Text;
                    data.Edad = Convert.ToInt32(txtEdad.Text);
                }

                db.Persona.Add(data);
                db.SaveChanges();
                MessageBox.Show("Persona Insertada Correctamente!!");
            }
            this.DATOS();
        }

        private void dgvPersona_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvPersona_SelectionChanged(object sender, EventArgs e)
        {
            txtNombre.Text = dgvPersona.CurrentRow.Cells["Nombre"].Value.ToString();
            txtEdad.Text = dgvPersona.CurrentRow.Cells["Edad"].Value.ToString();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvPersona.CurrentRow.Cells["IdPersona"].Value);

            using (CRUD_PERSONA_BDEntities db = new CRUD_PERSONA_BDEntities())
            {
                Persona data = new Persona();

                if (txtNombre.Text.Length <= 0 || txtEdad.Text.Length <= 0)
                {
                    MessageBox.Show("Digite datos validos para ACTUALIZAR la persona");
                    return;
                }
                else
                {
                    data.IdPersona = id;
                    data.Nombre = txtNombre.Text;
                    data.Edad = Convert.ToInt32(txtEdad.Text);
                    db.Entry(data).State = EntityState.Modified;
                    db.SaveChanges();
                }
                this.DATOS();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvPersona.CurrentRow.Cells["IdPersona"].Value);

            using (CRUD_PERSONA_BDEntities db = new CRUD_PERSONA_BDEntities())
            {
                var lst = db.Persona.Where(x => x.IdPersona == id).FirstOrDefault();
                db.Persona.Remove(lst);
                db.SaveChanges();
            }
            this.DATOS();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            using (CRUD_PERSONA_BDEntities db = new CRUD_PERSONA_BDEntities())
            {
               
            }
        }
    }
}
