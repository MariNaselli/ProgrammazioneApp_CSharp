using AdopcionesDAL;
using AdopcionesModels;
using AdopcionesWinForms.Properties;

namespace WinFormsApp_Adopciones
{
    public partial class Form1 : Form
    {
        SqlAnimales sqlAnimales;
        SqlAnimalesTipos sqlAnimalesTipos;

        public Form1()
        {
            InitializeComponent();
            string connectionString = Settings.Default.SQLLiteConnectionString;
            sqlAnimales = new SqlAnimales(connectionString);
            sqlAnimalesTipos = new SqlAnimalesTipos(connectionString);

            agregarAnimaleTiposAlComboBox();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            buscarAnimales();
        }

        private void buscarAnimales()
        {
            string textoBuscar = txtBuscar.Text;
            List<Animal> animalesList = sqlAnimales.GetAnimalesList(textoBuscar);
            agregarItemsAlListBox(animalesList);
        }

        private void agregarAnimaleTiposAlComboBox()
        {
            List<AnimalTipo> animalTipos = sqlAnimalesTipos.GetAnimalesTiposList();
            for (int i = 0; i < animalTipos.Count; i++)
            {
                AnimalTipo animalTipo = animalTipos[i];
                cmbAnimalTipo.Items.Add(animalTipo);
            }
            cmbAnimalTipo.DisplayMember = "Nombre_tipo";
        }

        private void agregarItemsAlListBox(List<Animal> animalesList)
        {
            listBoxResult.Items.Clear();
            foreach (Animal animal in animalesList)
            {
                listBoxResult.Items.Add(animal);
            }

            // Especifica la propiedad que quieres mostrar en el ListBox
            listBoxResult.DisplayMember = "Nombre";
        }

        private void listBoxResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifica si hay algún elemento seleccionado en el ListBox
            if (listBoxResult.SelectedItem != null)
            {
                // Convierte el elemento seleccionado a Animal
                Animal animalSeleccionado = (Animal)listBoxResult.SelectedItem;

                tabControlAnimal.Visible = true;

                // Ahora puedes trabajar con el animal seleccionado
                // Por ejemplo, puedes mostrar su nombre en un MessageBox
                //MessageBox.Show($"Animal seleccionado: {animalSeleccionado.Nombre}");

                lblAnimalId.Text = animalSeleccionado.Id_animal.ToString();
                txtNombre.Text = animalSeleccionado.Nombre;
                txtDescripcion.Text = animalSeleccionado.Descripcion;
                cmbGenero.SelectedItem = animalSeleccionado.Genero;
                dateTimeFechaNacimiento.Value = animalSeleccionado.Fecha_nacimiento;
                dateTimeFechaIngreso.Value = animalSeleccionado.Fecha_ingreso;
                cmbAnimalTipo.SelectedItem = animalSeleccionado.Tipo;

                // Busca el AnimalTipo correspondiente y selecciónalo en el ComboBox
                foreach (AnimalTipo tipo in cmbAnimalTipo.Items)
                {
                    if (tipo.Id_tipo == animalSeleccionado.Tipo.Id_tipo)
                    {
                        cmbAnimalTipo.SelectedItem = tipo;
                        break;
                    }
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = "";
            Animal animal = new Animal();
            animal.Id_animal = Convert.ToInt32(lblAnimalId.Text);
            animal.Nombre = txtNombre.Text;
            animal.Fecha_nacimiento = dateTimeFechaNacimiento.Value;
            animal.Genero = cmbGenero.SelectedItem.ToString();
            animal.Descripcion = txtDescripcion.Text;
            animal.Fecha_ingreso = dateTimeFechaIngreso.Value;
            animal.Tipo = (AnimalTipo)cmbAnimalTipo.SelectedItem;
            if (animal.Id_animal == 0)
            {
                //Es un nuevo animal, insertarlo en la base de datos
                sqlAnimales.InsertAnimal(animal);
                mensaje = "El Animal se registró correctamente";
            }
            else
            {
                //El animal ya existe, actualizarlo en la base de datos
                sqlAnimales.UpdateAnimal(animal);
                mensaje = "Animal actualizado correctamente!";
            }

            buscarAnimales();

            MessageBox.Show(mensaje, "Animal Guardado", MessageBoxButtons.OK);
        }

        private void nuevoAnimalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiarControles();
            tabControlAnimal.Visible = true;
        }

        private void limpiarControles()
        {
            lblAnimalId.Text = "0";
            cmbAnimalTipo.SelectedIndex = 0;
            txtNombre.Text = string.Empty;
            dateTimeFechaNacimiento.Value = DateTime.Today;
            cmbGenero.SelectedIndex = 0;
            txtDescripcion.Text = string.Empty;
            dateTimeFechaIngreso.Value = DateTime.Today;
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada es Enter (código ASCII 13)
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Llama al método para buscar animales
                buscarAnimales();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Verifica si hay un animal seleccionado en el ListBox
            if (listBoxResult.SelectedItem != null)
            {
                // Muestra un cuadro de diálogo de confirmación
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar este animal?", "Confirmación de eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Verifica si el usuario ha confirmado la eliminación
                if (result == DialogResult.Yes)
                {
                    // Obtiene el animal seleccionado
                    Animal animalSeleccionado = (Animal)listBoxResult.SelectedItem;

                    // Llama al método para eliminar el animal de la base de datos
                    sqlAnimales.DeleteAnimal(animalSeleccionado.Id_animal);

                    // Vuelve a cargar la lista de animales después de eliminar el animal
                    buscarAnimales();

                    limpiarControles();

                    tabControlAnimal.Visible = false;

                    // Muestra un mensaje de éxito
                    MessageBox.Show("El animal ha sido eliminado correctamente.", "Eliminación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }
            else
            {
                // Muestra un mensaje si no hay un animal seleccionado en el ListBox
                MessageBox.Show("Por favor, selecciona un animal para eliminar.", "Selección requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            tabControlAnimal.Visible = false;
        }
    }
}
