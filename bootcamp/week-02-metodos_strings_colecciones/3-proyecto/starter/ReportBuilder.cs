// ============================================
// ReportBuilder: reporte de texto alineado
// ============================================
// NOTA PARA EL APRENDIZ:
// Adapta cabeceras y columnas a tu dominio. Documenta en tu README la cultura elegida.

using System.Globalization;
using System.Text;

public static class ReportBuilder
{
    public static string Build(Catalog catalog, CultureInfo culture)
    {
        ArgumentNullException.ThrowIfNull(catalog);
        var sb = new StringBuilder();
        // TODO: cabecera alineada, p. ej. $"{"Clave",-8}{"Nombre",-22}{"Valor",10}{"Uds",5}{"Total",12}"
        sb.AppendLine(string.Create(culture, $"{"Clave",-8}{"Nombre",-22}{"Valor",10}{"Uds",5}{"Total",12}"));
        sb.AppendLine(new string('-', 57));

        decimal grandTotal = 0;
        foreach (Item item in catalog.Items)
            grandTotal += item.Value * item.Count;

        // TODO: recorrer catalog.GroupByCategory(); por cada grupo:
        //   - una línea de cabecera "[categoría]"
        //   - una línea por item con columnas alineadas y :N2
        //   - subtotal del grupo y su porcentaje sobre grandTotal con :P1
        foreach (Item item in catalog.Items)
            sb.AppendLine(string.Create(culture, $"{item.Key,-8}{item.Name,-22}{item.Value,10:N2}{item.Count,5}{item.Value * item.Count,12:N2}"));

        sb.AppendLine(new string('-', 57));
        sb.Append(string.Create(culture, $"{"TOTAL",-45}{grandTotal,12:N2}"));
        return sb.ToString();
    }
}
