<template>
    <div class="modal" id="addMovieModal">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Add Movie</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-12 form-group">
                            <label>Title</label>
                            <input type="text" class="form-control" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-12 form-group">
                            <label>Release Date</label>
                            <input type="date" class="form-control" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-12 form-group">
                            <label>Genre</label>
                            <select class="custom-select form-control">
                                <option>&mdash; Select Genre &mdash;</option>
                                <option v-for="item in genres" :value="item.id">{{item.name}}</option>
                            </select>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button class="btn btn-primary">Save</button>
                    <button class="btn btn-secondary" data-dismiss="modal">Cancel</button>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    export default {
        props: {
            showModal: Boolean
            //Todo: Notify Parent of save
        },
        emits: ["update:showModal"],
        data() {
            return {
                genres: []
                //Todo: Add Media Properties & bind to Fields
            };
        },
        watch: {
            showModal: function (newVal) {
                if (newVal)
                    $("#addMovieModal").modal('show');
                else
                    $("#addMovieModal").modal('hide');
            }
        },
        methods: {
            loadGenre() {
                fetch("api/media/getgenre")
                    .then((rsp) => {
                        if (rsp.ok)
                            return rsp.json();
                        else
                            throw new Error(rsp);
                    })
                    .then((data) => {
                        this.genres = data;
                    });
            },
            save() {
                //Todo: Post Media object                

                //Todo: Save Media Object
                fetch("", {
                    method: "POST",
                    headers: {
                        "Content-Type": "application/json"
                    },
                    //body: //Todo: Obejct here
                })
            }
        },
        mounted() {
            let self = this;
            self.loadGenre();
            $("#addMovieModal").modal({
                background: 'static',
                show: false
            })                
            .on("hidden.bs.modal", function () {
                self.$emit("update:showModal", false);
            });
        }
    }
</script>