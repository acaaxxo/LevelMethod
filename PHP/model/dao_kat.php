<?php
class dao_kat
{

    private $db;

    public function __construct()
    {
        $this->db = new db(DB_HOST, DB_USER, DB_PASS, DB_NAME);
    }

    // select database
    public function select()
    {
        $sql = "select * from mhskampus";
        $hasil = $this->db->proses($sql);
        $result = array();
        while ($baris = mysqli_fetch_array($hasil)) {
            $kat = new kat();
            $kat->set_id($baris['mhs_id']);
            $kat->set_nama($baris['mhs_name']);
            $kat->set_desc($baris['mhs_jur']);
            $result[] = $kat;
        }
        return $result;
    }

    // insert database
    public function simpan($nama, $desc)
    {
        $sql = "INSERT into mhskampus(mhs_id,mhs_jur) values('" . $nama . "','" . $desc . "')";
        $hasil = $this->db->proses($sql);
        return $hasil;
    }

    // delete 
    public function delete($id)
    {
        $sql = "DELETE from mhskampus where mhs_id= '" . $id . "'";
        $hasil = $this->db->proses($sql);
        return $hasil;
    }

    // update
    public function update($id, $nama, $desc)
    {
        $sql = "UPDATE mhskampus
        SET mhs_id = '" . $nama . "', mhs_jur = '" . $desc . "'
        WHERE mhs_id = '" . $id . "';";
        $hasil = $this->db->proses($sql);
        return $hasil;
    }
}
