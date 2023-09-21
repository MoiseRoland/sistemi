using System;
class HelloWorld
{
  static void Main ()
  {
    string targa;
    int valore;
      Console.WriteLine ("Inserisci una targa nel formato LLCCCLL");
      targa = Console.ReadLine ().ToUpper ();
    if (!Verifica (targa))
        Console.WriteLine ("Inserimento della targa sbagliato");
    else
      {
	valore = CalcoloTarga (targa);
	Console.WriteLine ("Il valore della targa e': " + valore);
      }
    Console.ReadLine ();
  }
  static bool Verifica (string targa)
  {
    for (int i = 0; i < targa.Length; i++)
      {
	if (((i < 2 || i > 4) && (targa[i] < 65 || targa[i] > 90))
	    || ((i > 1 && i < 5) && (targa[i] < 48 || targa[i] > 57)))
	  {
	    return false;
	  }
      }
    return true;
  }
  static int CalcoloTarga (string targa)
  {
    int valore = 0;
    for (int i = 0; i < targa.Length; i++)
      {
	if (i < 2)
	  {
	    valore = valore * 26 + ((int) targa[i] - (int) 'A');
	  }
	else if (i >= 2 && i < 5)
	  {
	    valore = valore * 10 + ((int) targa[i] - (int) '0');
	  }
	else if (i >= 5 && i < 7)
	  {
	    valore = valore * 26 + ((int) targa[i] - (int) 'A');
	  }
      }
    return valore;
  }
}
