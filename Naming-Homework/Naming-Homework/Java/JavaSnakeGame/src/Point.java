import java.awt.Color;
import java.awt.Graphics;
import java.awt.Rectangle;

public class Point {
	private int x, y;
	private final int WIDTH = 20;
	private final int HEIGHT = 20;
	
	public Point(Point p){
		this(p.xiks, p.igrek);
	}
	
	public Point(int x, int y){
		this.x = x;
		this.y = y;
	}	
		
	public int getX() {
		return this.x;
	}
	public void setX(int x) {
		this.x = x;
	}
	public int getY() {
		return this.y;
	}
	public void setY(int y) {
		this.y = y;
	}
	
	public void paintPoint(Graphics g, Color color) {
		g.setColor(Color.BLACK);
		g.fillRect(this.getX(), this.getY(), this.WIDTH, this.HEIGHT);
		g.setColor(color);
		g.fillRect(this.getX() + 1, this.getY() + 1, this.WIDTH - 2, this.HEIGHT - 2);		
	}
	
	public String toString() {
		return "[x=" + this.getX() + ",y=" + this.getY() + "]";
	}
	
	public boolean equals(Object pointObj) {
        if (point instanceof Point) {
            Point point = (Point)pointObj;
            return (this.getX() == point.getX()) && (this.getY() == point.getY());
        }
        return false;
    }
}
