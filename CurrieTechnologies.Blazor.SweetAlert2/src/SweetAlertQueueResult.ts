import Swal from "sweetalert2";

export default interface ISweetAlertQueueResult {
  value?: any[];
  dismiss?: Swal.DismissReason;
}
