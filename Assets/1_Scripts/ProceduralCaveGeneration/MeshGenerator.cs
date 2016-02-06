using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MeshGenerator : MonoBehaviour
{

    public SquareGrid squareGrid;
    List<Vector3> vertices;
    List<int> triangles;

    public void GenerateMesh( int[,] map, float squareSize )
    {
        squareGrid = new SquareGrid( map, squareSize );

        for( int x = 0; x < squareGrid.squares.GetLength( 0 ); x++ )
        {
            for( int y = 0; y < squareGrid.squares.GetLength( 1 ); y++ )
            {
                TriangulateSqure( squareGrid.squares[x, y] );
            }
        }
    }

    void TriangulateSqure( Square square )
    {
        switch( square.configuration )
        {
            case 0:
                break;

            // 1 points
            case 1:
                MeshFromPoints(
                    square.centreBottom,
                    square.bottomLeft,
                    square.centreLeft
                    );
                break;
            case 2:
                MeshFromPoints(
                    square.centreRight,
                    square.bottomRight,
                    square.centreBottom
                    );
                break;
            case 4:
                MeshFromPoints(
                    square.centreTop,
                    square.topRight,
                    square.centreRight
                    );
                break;
            case 8:
                MeshFromPoints(
                    square.topRight,
                    square.centreLeft,
                    square.centreTop
                    );
                break;

            // 2 points
            case 3:
                MeshFromPoints(
                    square.bottomLeft,
                    square.centreLeft,
                    square.centreRight,
                    square.bottomRight
                    );
                break;
            case 5:
                MeshFromPoints(
                    square.bottomLeft,
                    square.centreBottom,
                    square.centreLeft,
                    square.centreRight,
                    square.topRight,
                    square.centreTop );
                break;
            case 6:
                MeshFromPoints(
                    square.topRight,
                    square.bottomRight,
                    square.centreTop,
                    square.centreBottom );
                break;
            case 9:
                MeshFromPoints(
                    square.topLeft,
                    square.bottomLeft,
                    square.centreTop,
                    square.centreBottom
                    );
                break;
            case 10:
                MeshFromPoints(
                    square.topLeft,
                    square.centreTop,
                    square.centreLeft,
                    square.centreRight,
                    square.centreBottom,
                    square.bottomRight
                    );
                break;
            case 12:
                MeshFromPoints(
                    square.topLeft,
                    square.topRight,
                    square.centreLeft,
                    square.centreRight
                    );
                break;

            // 3 points
            case 7:
                MeshFromPoints(
                    square.topRight,
                    square.centreTop,
                    square.centreLeft,
                    square.bottomLeft,
                    square.bottomRight
                    );
                break;
            case 11:
                MeshFromPoints(
                    square.topLeft,
                    square.centreTop,
                    square.centreRight,
                    square.bottomLeft,
                    square.bottomRight
                    );
                break;
            case 13:
                MeshFromPoints(
                    square.topLeft,
                    square.topRight,
                    square.centreRight,
                    square.bottomLeft,
                    square.centreBottom
                    );
                break;
            case 14:
                MeshFromPoints(
                    square.topLeft,
                    square.topRight,
                    square.centreLeft,                    
                    square.centreBottom,
                    square.bottomRight
                    );
                break;
            case 15:
                MeshFromPoints(
                    square.topLeft,
                    square.topRight,
                    square.bottomLeft,
                    square.bottomRight,
                    square.centreBottom
                    );
                break;
        }
    }
    void MeshFromPoints( params Node[] points )
    {
        AssignVertices( points );
    }

    void AssignVertices(Node[] points )
    {
        for( int i = 0; i < points.Length; i++ )
        {
            if( points[i].vertexIndex == -1 )
            {
                points[i].vertexIndex = vertices.Count;
                vertices.Add( points[i].position ); 
            }
        }
    }

    void OnDrawGizmos()
    {
        if( squareGrid != null )
        {
            for( int x = 0; x < squareGrid.squares.GetLength( 0 ); x++ )
            {
                for( int y = 0; y < squareGrid.squares.GetLength( 1 ); y++ )
                {

                    Gizmos.color = (squareGrid.squares[x, y].topLeft.active) ? Color.black : Color.white;
                    Gizmos.DrawCube( squareGrid.squares[x, y].topLeft.position, Vector3.one * .4f );

                    Gizmos.color = (squareGrid.squares[x, y].topRight.active) ? Color.black : Color.white;
                    Gizmos.DrawCube( squareGrid.squares[x, y].topRight.position, Vector3.one * .4f );

                    Gizmos.color = (squareGrid.squares[x, y].bottomRight.active) ? Color.black : Color.white;
                    Gizmos.DrawCube( squareGrid.squares[x, y].bottomRight.position, Vector3.one * .4f );

                    Gizmos.color = (squareGrid.squares[x, y].bottomLeft.active) ? Color.black : Color.white;
                    Gizmos.DrawCube( squareGrid.squares[x, y].bottomLeft.position, Vector3.one * .4f );


                    Gizmos.color = Color.grey;
                    Gizmos.DrawCube( squareGrid.squares[x, y].centreTop.position, Vector3.one * .15f );
                    Gizmos.DrawCube( squareGrid.squares[x, y].centreRight.position, Vector3.one * .15f );
                    Gizmos.DrawCube( squareGrid.squares[x, y].centreBottom.position, Vector3.one * .15f );
                    Gizmos.DrawCube( squareGrid.squares[x, y].centreLeft.position, Vector3.one * .15f );

                }
            }
        }
    }

    public class SquareGrid
    {
        public Square[,] squares;

        public SquareGrid( int[,] map, float squareSize )
        {
            int nodeCountX = map.GetLength( 0 );
            int nodeCountY = map.GetLength( 1 );
            float mapWidth = nodeCountX * squareSize;
            float mapHeight = nodeCountY * squareSize;

            ControlNode[,] controlNodes = new ControlNode[nodeCountX, nodeCountY];

            for( int x = 0; x < nodeCountX; x++ )
            {
                for( int y = 0; y < nodeCountY; y++ )
                {
                    Vector3 pos = new Vector3(
                                                -mapWidth / 2 + x * squareSize + squareSize / 2,
                                                0,
                                                -mapHeight / 2 + y * squareSize + squareSize / 2
                                                );
                    controlNodes[x, y] = new ControlNode( pos, map[x, y] == 1, squareSize );
                }
            }

            squares = new Square[nodeCountX - 1, nodeCountY - 1];
            for( int x = 0; x < nodeCountX - 1; x++ )
            {
                for( int y = 0; y < nodeCountY - 1; y++ )
                {
                    squares[x, y] = new Square( controlNodes[x, y + 1], controlNodes[x + 1, y + 1], controlNodes[x + 1, y], controlNodes[x, y] );
                }
            }

        }
    }

    public class Square
    {
        public ControlNode topLeft, topRight, bottomRight, bottomLeft;
        public Node centreTop, centreRight, centreBottom, centreLeft;
        //Lesson 3
        public int configuration;


        public Square( ControlNode _topLeft, ControlNode _topRight, ControlNode _bottomRight, ControlNode _bottomLeft )
        {
            topLeft = _topLeft;
            topRight = _topRight;
            bottomRight = _bottomRight;
            bottomLeft = _bottomLeft;

            centreTop = topLeft.right;
            centreRight = bottomRight.above;
            centreBottom = bottomLeft.right;
            centreLeft = bottomLeft.above;

            //Lesson 3
            if( topLeft.active )
                configuration += 8;
            if( topRight.active )
                configuration += 4;
            if( bottomLeft.active )
                configuration += 1;
            if( bottomRight.active )
                configuration += 2;
        }
    }

    public class Node
    {
        public Vector3 position;
        public int vertexIndex = -1;

        public Node( Vector3 _pos )
        {
            position = _pos;
        }
    }

    public class ControlNode : Node
    {

        public bool active;
        public Node above, right;

        public ControlNode( Vector3 _pos, bool _active, float squareSize ) : base( _pos )
        {
            active = _active;
            above = new Node( position + Vector3.forward * squareSize / 2f );
            right = new Node( position + Vector3.right * squareSize / 2f );
        }

    }
}