import os
import glob
#os.system(r' "C:\Program Files\Unity\Hub\Editor\2018.4.35f1\Editor\unity.exe" -quit -batchmode -executeMethod BuilderLinhaComando.PerformBuild ') #os.system(' ') roda linhas de comando no cmd

# todos os arquivos terminados em .png
#BACKGROUND
f = open("Assets/Resources/lista.txt", "a")
for file in glob.glob("Assets/Resources/backgrounds/*.png"):
   print(file)
   f.write(str(file).replace('Assets/Resources/', '') + ";0;0;" + "\n")

for file in glob.glob("Assets/Resources/backgrounds/*.jpg"):
   print(file)
   f.write(str(file).replace('Assets/Resources/', '') + ";0;0;" + "\n")

f.close()

#OBJETOS
i=0;
f = open("Assets/Resources/lista.txt", "a")

for file in glob.glob("Assets/Resources/objetos/*.png"):
   f.write(str(file).replace('Assets/Resources/', '') + ";1;" + str(i) + ";" + "\n")
   i+1

for file in glob.glob("Assets/Resources/objetos/*.jpg"):
   f.write(str(file).replace('Assets/Resources/', '') + ";1;" + str(i) + ";" + "\n")
   i+1

f.close()

#VEGETAÇAO
i=0;
f = open("Assets/Resources/lista.txt", "a")
for file in glob.glob("Assets/Resources/vegetacao/*.png"):
   f.write(str(file).replace('Assets/Resources/', '') + ";2;" + str(i) + ";" + "\n")
   i+1
for file in glob.glob("Assets/Resources/objetos/*.jpg"):
   f.write(str(file).replace('Assets/Resources/', '') + ";2;" + str(i) + ";" + "\n")
   i+1

f.close()

os.system(' C:\\"Program Files"\\Unity\\Hub\\Editor\\2018.4.35f1\\Editor\\unity.exe  -batchmode -quit -projectPath D:\Projetos\GEGRADI\Motivacao-Builder-LOCAL -executeMethod BuilderLinhaComando.PerformBuild') #os.system(' ') roda linhas de comando no cmd

exit()

