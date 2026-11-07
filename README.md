## 3D Software Renderer - Windows Forms

[En]
A simple 3D software renderer built from scratch in C# with Windows Forms. I built this project to understand the math behind 3D graphics, matrix rotations, and perspective projection without using any external game engines or 3D libraries.

## Features

- Pure Software Rendering: Everything is calculated on the CPU and drawn using GDI+ (System.Drawing).
- 3D Math: Implementation of Euler angles (X and Y axes) for 3D rotation.
- Perspective Projection: Conversion of 3D coordinates into 2D screen coordinates with depth.
- Interactive Controls: Rotate the cube using the keyboard or toggle automatic rotation.
- Data-Oriented Design: Clean separation of Vertices, Edges, and the 3D Object (Cube).

## How to run

- Download or clone this repository.
- Open 3DRenderer.sln in Visual Studio.
- Build and run the project.

The project targets .NET Framework 4.7.2 and is intended for Windows.

## Controls

| Key |	Action |
| ---- | ---- |
| ← / → |	Rotate the cube on the Y axis |
| ↑ / ↓ |	Rotate the cube on the X axis |
| Space	| Toggle automatic rotation |

## Architecture

The project is built with a focus on understanding the 3D graphics pipeline:

- Vertice (Vertex): Holds the 3D coordinates (X, Y, Z) and contains the mathematical logic for rotation using Sine and Cosine.
- Aresta (Edge): Connects two vertices, defining the wireframe structure.
- Cube: The 3D object that groups vertices and edges, and holds the current rotation angles.
- View (Windows Forms): Captures input and applies the Projection Matrix (dividing X and Y by Z) before rendering the lines on the screen.

## About

This is a personal learning project. My goal was to uderstand how 3D graphics work, learning about perspective, camera space, and the math behind rendering.

## Demo

<img width="317" height="309" alt="image" src="https://github.com/user-attachments/assets/9f7599f6-0e39-48ec-8a85-0d3f4266cb4d" />
<br>
<img width="317" height="310" alt="image" src="https://github.com/user-attachments/assets/a92c005f-87a8-4d1a-a2dd-718fb29de116" />
<br>
<img width="640" height="552" alt="winformCubeRender" src="https://github.com/user-attachments/assets/db377094-5dd5-43cd-b78d-f92f1cdea5cd" />

## Renderizador 3D por Software - Windows Forms

[Br]
Um renderizador 3D simples construído do zero em C# com Windows Forms. Eu criei esse projeto para entender a matemática por trás dos gráficos 3D, rotação de matrizes e projeção em perspectiva, sem usar nenhuma engine ou biblioteca gráfica de terceiros.

## Features

- Renderização Puramente em Software: Tudo é calculado na CPU e desenhado usando GDI+ (System.Drawing).
- Matemática 3D: Implementação de ângulos de Euler (eixos X e Y) para rotação tridimensional.
- Projeção em Perspectiva: Conversão de coordenadas 3D para 2D na tela com sensação de profundidade.
- Controles Interativos: Rotacione o cubo pelo teclado ou ative a rotação automática.
- Design Orientado a Dados: Separação limpa entre Vértices, Arestas e o Objeto 3D (Cubo).

## Como rodar o projeto

- Faça o download ou clone esse repositório.
- Abra 3DRenderer.sln no Visual Studio.
- Faça a build da solução e execute o projeto.

O projeto foi feito para o .NET Framework 4.7.2 e é planejado para Windows.

## Controles

| Tecla |	Ação |
| ← / → |	Rotaciona o cubo no eixo Y |
| ↑ / ↓	| Rotaciona o cubo no eixo X |
| Espaço |	Liga/Desliga a rotação automática |

## Arquitetura

O projeto foi construído com foco em entender o pipeline de gráficos 3D:

- Vertice (Vértice): Armazena as coordenadas 3D (X, Y, Z) e contém a lógica matemática de rotação usando Seno e Cosseno.
- Aresta: Conecta dois vértices, definindo a estrutura de arame (wireframe).
- Cube: O objeto 3D que agrupa vértices e arestas, e mantém os ângulos atuais de rotação.
- View (Windows Forms): Captura o input e aplica a Projeção (dividindo X e Y por Z) antes de renderizar as linhas na tela.

## Sobre

Esse é um projeto pessoal de estudo. Meu objetivo foi entender como os gráficos 3D funcionam, aprendendo sobre perspectiva, espaço de câmera e a matemática por trás da renderização.

## Demo

<img width="317" height="309" alt="image" src="https://github.com/user-attachments/assets/9f7599f6-0e39-48ec-8a85-0d3f4266cb4d" />
<br>
<img width="317" height="310" alt="image" src="https://github.com/user-attachments/assets/a92c005f-87a8-4d1a-a2dd-718fb29de116" />
<br>
<img width="640" height="552" alt="winformCubeRender" src="https://github.com/user-attachments/assets/dbbc2bbd-6e4d-4cb7-bbd8-23b1899036e1" />
