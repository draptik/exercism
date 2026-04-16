public class JedliksToyCar {
    private int distanceDriven = 0;
    private int batteryStatus = 100;

    public static JedliksToyCar buy() {
        return new JedliksToyCar();
    }

    public String distanceDisplay() {
        return "Driven " + distanceDriven + " meters";
    }

    public String batteryDisplay() {
        if (batteryStatus == 0) {
            return "Battery empty";
        }
        return "Battery at " + batteryStatus + "%";
    }

    public void drive() {
        if (batteryStatus > 0) {
            distanceDriven += 20;
            batteryStatus -= 1;
        }
    }
}
