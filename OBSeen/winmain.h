#ifndef WINMAIN_H
#define WINMAIN_H

#include <QMainWindow>

namespace Ui {
class winMain;
}

class winMain : public QMainWindow
{
    Q_OBJECT

public:
    explicit winMain(QWidget *parent = 0);
    ~winMain();

private:
    Ui::winMain *ui;
};

#endif // WINMAIN_H
