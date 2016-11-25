#include "winmain.h"
#include "ui_winmain.h"

winMain::winMain(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::winMain)
{
    ui->setupUi(this);
}

winMain::~winMain()
{
    delete ui;
}
