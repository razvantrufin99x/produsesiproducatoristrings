using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace produse
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public class producator
        {
            public string codproducator;
            public string denumire;
            public string datedecontact;
            public string cif;
            public produseLista listadeproduse = new produseLista();
            public producator() { }
            public producator(string pcodproducator, string pdenumire, string pdatedecontact, string pcif) 
            {
                codproducator = pcodproducator;
                denumire = pdenumire;
                datedecontact = pdatedecontact;
                cif = pcif;
            }
            public string print()
            {
                return this.codproducator + " ," + this.denumire + " , " + this.datedecontact + " , " + this.cif;
             }
        }   
        
        public class producatorLista
        {
            public List<producator> lista = new List<producator>();
            public void adauga(producator pp) { lista.Add(pp); }
        }

        public class produs
        {
            public string codprodus;

            public string codproducator;

            public string denumire;
            public string descriere;
            public float pret;
            public float cotatva;

            public produs() { }
            public produs(string pcodprodus, string pdenumire, string pcodproducator, string pdescriere, float ppret, float pcotatva ) 
            {
                codprodus = pcodprodus;
                denumire = pdenumire;
                codproducator = pcodproducator;
                descriere = pdescriere;
                pret = ppret;
                cotatva = pcotatva;
            }
            public string print()
            {
                return this.codprodus + " ," + this.denumire + " , " + this.codproducator + " , " + this.descriere + "," + pret.ToString() + "," + cotatva.ToString();
            }
        }

        public class produseLista
        { 
            public List<produs> lista = new List<produs>();
            public void adauga(produs pp) { lista.Add(pp); }
        }
        public class depozit
        {
            public string coddepozit;
            public string denumire;
            public string proprietar;
            public producatorLista listadeproducatori = new producatorLista();
            public depozit() { }
            public depozit(string pcoddepozit, string pdenumire, string pproprietar) 
            { 
                coddepozit = pcoddepozit;
                denumire = pdenumire;
                proprietar = pproprietar;
            }

            public string printProducatorul(int x) { return this.listadeproducatori.lista[x].print(); }
            public List<string> printListaDeProducatori() { 
                List<string> retlist = new List<string>();
                for (int i = 0; i < this.listadeproducatori.lista.Count; i++)
                {
                    retlist.Add(this.listadeproducatori.lista[i].print());
                }
                return retlist;
            }
            public List<string> printListaDeProduse(int indexproducator)
            {
                List<string> retlist = new List<string>();
                for (int i = 0; i < listadeproducatori.lista[indexproducator].listadeproduse.lista.Count; i++)
                {
                    retlist.Add(this.listadeproducatori.lista[indexproducator].listadeproduse.lista[i].print());
                }
                return retlist;
            }
            public string printProdusul(int indexproducator, int indexprodus)
            {
                return this.listadeproducatori.lista[indexproducator].listadeproduse.lista[indexprodus].print();
            }
         
        }
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            depozit depozitmateriale = new depozit("depmatsan1", "depozitdematerialesanitare1", "Alexandru Vacarescu");
            depozitmateriale.listadeproducatori.adauga(
                new producator("BYR", "Bayer GB Germany", "adresa Germania, telefon nu stiu, email nustiu,...blablabla", "83749832gjhgj3432432432")
                );
            int current = 0;
            current = depozitmateriale.listadeproducatori.lista.Count;
            depozitmateriale.listadeproducatori.lista[current - 1].listadeproduse.adauga(
                new produs("SM120", "seringa mare 120ml", "BYR", "seringa pentru uz unic de 120ml", 0.56f, 1.0f)
                );
            current = depozitmateriale.listadeproducatori.lista.Count;
            depozitmateriale.listadeproducatori.lista[current - 1].listadeproduse.adauga(
                new produs("Sm20", "seringa mica 20ml", "BYR", "seringa pentru uz unic de 20ml", 0.26f, 1.0f)
                );

            List<string> listacuproducatorii = depozitmateriale.printListaDeProducatori();
            for (int i = 0; i < listacuproducatorii.Count; i++)
            {
                textBox1.Text += listacuproducatorii[i] + "\r\n";
            }
            List<string> listacuprodusele = depozitmateriale.printListaDeProduse(0);
            for (int i = 0; i < listacuprodusele.Count; i++)
            {
                textBox1.Text += listacuprodusele[i] + "\r\n";
            }
        }
    }
}
