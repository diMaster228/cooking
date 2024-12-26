using MaterialSkin;
using MaterialSkin.Controls;

public class BaseMaterialForm : MaterialForm
{
    public BaseMaterialForm()
    {
        // Настраиваем MaterialSkinManager
        var materialSkinManager = MaterialSkinManager.Instance;
        materialSkinManager.AddFormToManage(this);
        materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
        materialSkinManager.ColorScheme = new ColorScheme(
            Primary.Blue500, Primary.Blue700,
            Primary.Blue200, Accent.LightBlue200,
            TextShade.WHITE
        );
    }
}
