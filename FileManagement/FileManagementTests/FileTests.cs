using FileManagementService;

namespace FileManagementTests
{
    public class FileTests
    {
        //ADIÇAO ARQUIVOS
        [Fact]
        public void DeveRetornarSucessoAdicaoArquivo()
        {
            //Arrange
            string[][] query = new string[][] { new string[] { "ADD_FILE", "/file.txt", "10" } };
            string[] expected = new string[] { "true" };

            //Act
            var result = FileService.FileInputManagment(query);

            //Assert
            Assert.Equal(expected, result);
        }

        //BUSCA ARQUIVOS

        [Fact]
        public void DeveRetornarSucessoBuscaArquivo()
        {
            //Arrange
            string[][] query = new string[][] {
            new string[] { "ADD_FILE","/src/main.cpp","20" },
            new string[] { "GET_FILE_SIZE", "/src/main.cpp" }
            };

            string[] expected = new string[] { "true", "20" };

            //Act
            var result = FileService.FileInputManagment(query);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void DeveRetornarFalhaBuscaArquivo()
        {
            //Arrange
            string[][] query = new string[][] {
            new string[] { "GET_FILE_SIZE", "/src/main.cpp" }
            };

            string[] expected = new string[] { "null" };

            //Act
            var result = FileService.FileInputManagment(query);

            //Assert
            Assert.Equal(expected, result);
        }

        // DELEÇÂO DE ARQUIVOS

        [Fact]
        public void DeveRetornarFalhaDeletarArquivo()
        {
            //Arrange
            string[][] query = new string[][] {
            new string[] { "DELETE_FILE", "/src/main.cpp" }
            };

            string[] expected = new string[] { "null" };

            //Act
            var result = FileService.FileInputManagment(query);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void DeveRetornarSucessoDeletarArquivo()
        {
            //Arrange
            string[][] query = new string[][] {
            new string[] { "ADD_FILE","/src/main.cpp","20" },
            new string[] { "DELETE_FILE", "/src/main.cpp" }
            };

            string[] expected = new string[] { "true", "deleted" };

            //Act
            var result = FileService.FileInputManagment(query);

            //Assert
            Assert.Equal(expected, result);
        }

        //COPIA DE ARQUIVOS
        [Fact]
        public void DeveRetornarSucessoCopiarArquivo()
        {
            //Arrange
            string[][] query = new string[][] {
            new string[] { "ADD_FILE","/src/main.cpp","20" },
            new string[] { "COPY_FILE", "/src/main.cpp", "/src/main-copy.cpp" },
            new string[] { "GET_FILE_SIZE", "/src/main-copy.cpp" },
        };

            string[] expected = new string[] { "true", "/src/main-copy.cpp", "20" };

            //Act
            var result = FileService.FileInputManagment(query);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void DeveRetornarFalhaBuscaArquivoCopiadoCopiarArquivo()
        {
            //Arrange
            string[][] query = new string[][] {
            new string[] { "ADD_FILE","/src/main.cpp","20" },
            new string[] { "COPY_FILE", "/src/main.cpp", "/src/main-copy.cpp" },
            new string[] { "GET_FILE_SIZE", "/src/main-copy.cs" },
        };

            string[] expected = new string[] { "true", "/src/main-copy.cpp", "null" };

            //Act
            var result = FileService.FileInputManagment(query);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void DeveRetornarFalhaCopiarArquivo()
        {
            //Arrange
            string[][] query = new string[][] {
            new string[] { "ADD_FILE","/src/main.cpp","20" },
            new string[] { "COPY_FILE", "/src/main.cs", "/src/main-copy.cpp" },
            new string[] { "GET_FILE_SIZE", "/src/main-copy.cpp" },
        };

            string[] expected = new string[] { "true", "null", "null" };

            //Act
            var result = FileService.FileInputManagment(query);

            //Assert
            Assert.Equal(expected, result);
        }


    }
}